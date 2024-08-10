using Dapper;
using RealEstateDapperApi.Dtos.ProductImageDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ProductImageRepository
{
    public class ProductImageRepository:IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            string query = "insert into ProductImage (ImageUrl, ProductId) Values (@ImageUrl, @ProductId)";
            var parameters = new DynamicParameters();
            parameters.Add("@ImageUrl", createProductImageDto.ImageUrl);
            parameters.Add("@ProductId", createProductImageDto.ProductId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultGetProductImageByIdDto>> GetProductImageByProductId(int id)
        {
            string query = "Select *from ProductImage where ProductId=@ProductId";
            var parameter = new DynamicParameters();
            parameter.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultGetProductImageByIdDto>(query, parameter);
                return values.ToList();
            }
        }
    }
}
