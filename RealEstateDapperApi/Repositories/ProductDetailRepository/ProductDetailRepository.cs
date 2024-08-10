using Dapper;
using Humanizer.Localisation.TimeToClockNotation;
using RealEstateDapperApi.Dtos.AmenityDtos;
using RealEstateDapperApi.Dtos.ProductDetailDtos;
using RealEstateDapperApi.Dtos.ProductDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ProductDetailRepository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly Context _context;

        public ProductDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            string query = "insert into ProductDetails (Size, BedroomCount, BathCount, GarageSize, BuildYear, Location, VideoUrl, ProductId) Values (@Size, @BedroomCount, @BathCount, @GarageSize, @BuildYear, @Location, @VideoUrl, @ProductId)";
            var parameters = new DynamicParameters();
            parameters.Add("@Size", createProductDetailDto.Size);
            parameters.Add("@BedroomCount", createProductDetailDto.BedroomCount);
            parameters.Add("@BathCount", createProductDetailDto.BathCount);
            parameters.Add("@GarageSize", createProductDetailDto.GarageSize);
            parameters.Add("@BuildYear", createProductDetailDto.BuildYear);
            parameters.Add("@Location", createProductDetailDto.Location);
            parameters.Add("@VideoUrl", createProductDetailDto.VideoUrl);
            parameters.Add("@ProductId", createProductDetailDto.ProductId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

            var ProductId = createProductDetailDto.ProductId; 

            for(int i = 1; i<= 19; i++)
            {
                string queryAmenity = "insert into ProductAmenity (ProductId, AmenityId, Status) VALUES (@ProductId, @AmenityId, @Status)";
                var parametersAmenity = new DynamicParameters();
                parametersAmenity.Add("@ProductId", ProductId);
                parametersAmenity.Add("@AmenityId", i);
                parametersAmenity.Add("@Status", false);
                using (var con = _context.CreateConnection())
                {
                    var values = await con.ExecuteAsync(queryAmenity, parametersAmenity);
                }

            }
        }

        public async Task DeleteProductDetail(int id)
        {
            string query = "Delete from ProductDetails where ProductDetailId=@ProductDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductDetailId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetails()
        {
            string query = "Select *from ProductDetails " +
                "inner join Product on Product.ProductId = ProductDetails.ProductId";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdProductDetailForUpdateDto> GetByIdProductDetailForUpdate(int id)
        {
            string query = "Select *from ProductDetails where ProductDetailId=@ProductDetailId";
            var parameter = new DynamicParameters();
            parameter.Add("@ProductDetailId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdProductDetailForUpdateDto>(query, parameter);
                return values;
            }
        }

        public async Task<ResultGetProductDetailByIdDto> GetProductDetailById(int id)
        {
            string query = "Select ProductDetailId, Size, BedroomCount, BathCount, GarageSize, BuildYear, Location, VideoUrl, ProductDetails.ProductId, Product.Price, Product.Title as \"Title\",   \r\nCoverImage, City, District, Address, Description, Type, Date, Name, Employee.Title as \"EmployeeTitle\", Mail, PhoneNumber, Employee.ImageUrl as \"ProfileUrl\" from ProductDetails \r\ninner join Product on ProductDetails.ProductId = Product.ProductId \r\ninner join Employee on Product.EmployeeId = Employee.EmployeeId\r\nwhere ProductDetailId=@ProductDetailId";
            var parameter = new DynamicParameters();
            parameter.Add("@ProductDetailId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<ResultGetProductDetailByIdDto>(query, parameter);
                return values;
            }
        }

        public async Task UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            string query = "Update ProductDetails set Size=@Size, BedroomCount=@BedroomCount, BathCount=@BathCount, RoomCount=@RoomCount, GarageSize=@GarageSize, BuildYear=@BuildYear, Location=@Location, VideoUrl=@VideoUrl where ProductDetailId=@ProductDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductDetailId", updateProductDetailDto.ProductDetailId);
            parameters.Add("@Size", updateProductDetailDto.Size);
            parameters.Add("@BedroomCount", updateProductDetailDto.BedroomCount);
            parameters.Add("@BathCount", updateProductDetailDto.BathCount);
            parameters.Add("@RoomCount", updateProductDetailDto.RoomCount);
            parameters.Add("@GarageSize", updateProductDetailDto.GarageSize);
            parameters.Add("@BuildYear", updateProductDetailDto.BuildYear);
            parameters.Add("@Location", updateProductDetailDto.Location);
            parameters.Add("@VideoUrl", updateProductDetailDto.VideoUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
