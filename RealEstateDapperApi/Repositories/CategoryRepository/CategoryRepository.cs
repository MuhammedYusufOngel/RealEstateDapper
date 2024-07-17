using Dapper;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //I dont know why but these codes don't work
            //string query = "insert into Category (CategoryName, CategoryStatus) values (" + createCategoryDto.CategoryName + "), (" + true + ")";
            //using(var connection = _context.CreateConnection())
            //{
            //    await connection.ExecuteAsync(query);
            //}

            string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete from Category where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategorySync()
        {
            string query = "Select* from Category";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategory(int id)
        {
            string query = "Select *from Category where CategoryId=@categoryId";
            var parameter = new DynamicParameters();
            parameter.Add("@categoryId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameter);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category set CategoryName=@categoryName, CategoryStatus=@categoryStatus where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", updateCategoryDto.CategoryStatus);
            parameters.Add("@categoryId", updateCategoryDto.CategoryId);
            using(var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
