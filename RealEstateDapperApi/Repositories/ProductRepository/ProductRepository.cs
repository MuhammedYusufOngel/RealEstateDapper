using Dapper;
using RealEstateDapperApi.Dtos.ProductDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async void CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title, Price, CoverImage, City, District, Address, Description, ProductCategory, EmployeeId, Type) values (@Title, @Price, @CoverImage, @City, @District, @Address, @Description, @ProductCategory, @EmployeeId, @Type)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@District", createProductDto.District);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmployeeId", createProductDto.EmployeeId);
            parameters.Add("@Type", createProductDto.Type);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select *from Product";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync()
        {
            string query = "Select ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName from Product inner join Category on Category.CategoryId = Product.ProductCategory";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
