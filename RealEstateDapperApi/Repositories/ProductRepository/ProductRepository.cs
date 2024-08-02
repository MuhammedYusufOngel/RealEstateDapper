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
            string query = "insert into Product (Title, Price, CoverImage, City, District, Address, Description, ProductCategory, EmployeeId, Type, DealOfTheDay, Date) values (@Title, @Price, @CoverImage, @City, @District, @Address, @Description, @ProductCategory, @EmployeeId, @Type, @DealOfTheDay, Date)";
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
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@Date", createProductDto.Date);
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
            string query = "Select ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<GetByIdProductDto>> GetByEmployeeIdProductsAsync(int id)
        {
            string query = "Select ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory where EmployeeId=@EmployeeId";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<GetByIdProductDto>(query, parameter);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory order by ProductId desc";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product set DealOfTheDay=0 where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product set DealOfTheDay=1 where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
