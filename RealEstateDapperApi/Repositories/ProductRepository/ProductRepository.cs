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

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title, Price, CoverImage, City, District, Address, Description, ProductCategory, EmployeeId, Type, DealOfTheDay, Status, Date) values (@Title, @Price, @CoverImage, @City, @District, @Address, @Description, @ProductCategory, @EmployeeId, @Type, @DealOfTheDay, @Status, @Date)";
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
            parameters.Add("@Status", true);
            parameters.Add("@Date", DateTime.Now.ToString());
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteProduct(int id)
        {
            string query = "Delete from Product where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
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
            string query = "Select ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Status, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<GetByIdProductDto>> GetByEmployeeIdProductsFalseAsync(int id)
        {
            string query = "Select ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Status, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory where EmployeeId=@EmployeeId and Status=0";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<GetByIdProductDto>(query, parameter);
                return values.ToList();
            }
        }

        public async Task<List<GetByIdProductDto>> GetByEmployeeIdProductsTrueAsync(int id)
        {
            string query = "Select ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Status, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory where EmployeeId=@EmployeeId and Status=1";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<GetByIdProductDto>(query, parameter);
                return values.ToList();
            }
        }

        public async Task<GetByIdProductForUpdateDto> GetByIdProduct(int id)
        {
            string query = "Select *from Product where ProductId=@ProductId";
            var parameter = new DynamicParameters();
            parameter.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdProductForUpdateDto>(query, parameter);
                return values;
            }
        }

        public async Task<List<ResultLast3ProductDto>> GetLast3ProductAsync()
        {
            string query = "Select Top(3) *from Product order by ProductId desc";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultLast3ProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Status, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory order by ProductId desc";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductByEmployeeIdDto>> GetLast5ProductByEmployeeIdAsync(int id)
        {
            string query = "Select Top(5) ProductId, Title, Price, CoverImage, City, District, Address, Type, Description, CategoryName, DealOfTheDay, Status, Date from Product inner join Category on Category.CategoryId = Product.ProductCategory where EmployeeId=@EmployeeId order by ProductId desc";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultLast5ProductByEmployeeIdDto>(query, parameter);
                return values.ToList();
            }
        }

        public async Task<ResultLastProductDto> GetLastProduct()
        {
            string query = "Select Top(1) *from Product order by ProductId desc";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<ResultLastProductDto>(query);
                return values;
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select *from Product inner join Category on Category.CategoryId = Product.ProductCategory where DealOfTheDay=1";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithSearchDto>> GetResultProductWithSearch(string searchKeyValue, int categoryId, string City)
        {
            string query = "Select *from Product\r\ninner join Category on Product.ProductCategory = Category.CategoryId where City=@City and ProductCategory=@ProductCategory and Title like '%" + searchKeyValue + "%' ";
            var parameters = new DynamicParameters();
            parameters.Add("@City", City);
            parameters.Add("@ProductCategory", categoryId);
            parameters.Add("@Title", searchKeyValue);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithSearchDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithSearchDto>> GetResultProductWithSearch(int categoryId, string City)
        {
            string query = "Select *from Product\r\ninner join Category on Product.ProductCategory = Category.CategoryId where City=@City and ProductCategory=@ProductCategory";
            var parameters = new DynamicParameters();
            parameters.Add("@City", City);
            parameters.Add("@ProductCategory", categoryId);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithSearchDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product set DealOfTheDay=0 where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product set DealOfTheDay=1 where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductStatusChangeToFalse(int id)
        {
            string query = "Update Product set Status=0 where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductStatusChangeToTrue(int id)
        {
            string query = "Update Product set Status=1 where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            string query = "Update Product set Title=@Title, Price=@Price, CoverImage=@CoverImage, City=@City, District=@District, Address=@Address, Description=@Description, Type=@Type, ProductCategory=@ProductCategory, EmployeeId=@EmployeeId where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", updateProductDto.ProductId);
            parameters.Add("@Title", updateProductDto.Title);
            parameters.Add("@Price", updateProductDto.Price);
            parameters.Add("@CoverImage", updateProductDto.CoverImage);
            parameters.Add("@City", updateProductDto.City);
            parameters.Add("@District", updateProductDto.District);
            parameters.Add("@Address", updateProductDto.Address);
            parameters.Add("@Description", updateProductDto.Description);
            parameters.Add("@ProductCategory", updateProductDto.ProductCategory);
            parameters.Add("@Type", updateProductDto.Type);
            parameters.Add("@EmployeeId", updateProductDto.EmployeeId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
