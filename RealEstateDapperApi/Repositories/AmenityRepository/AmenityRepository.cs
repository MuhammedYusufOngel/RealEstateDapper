using Dapper;
using Microsoft.CodeAnalysis;
using RealEstateDapperApi.Dtos.AmenityDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.AmenityRepository
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly Context _context;

        public AmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task DoAmenityStatusFalse(int productid, int amenityid)
        {
            var query = "Update ProductAmenity set Status=0 where ProductId=@ProductId and AmenityId=@AmenityId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", productid);
            parameters.Add("@AmenityId", amenityid);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task DoAmenityStatusTrue(int productid, int amenityid)
        {
            var query = "Update ProductAmenity set Status=1 where ProductId=@ProductId and AmenityId=@AmenityId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", productid);
            parameters.Add("@AmenityId", amenityid);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultAmenitiesDto>> GetAllAmenities()
        {
            string query = "Select* from Amenity";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultAmenitiesDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultGetAmenitiesByProductIdDto>> GetAmenitiesByProductId(int id)
        {
            string query = "Select *from ProductAmenity\r\ninner join Amenity on ProductAmenity.AmenityId = Amenity.AmenityId where ProductId = @ProductId";
            var parameter = new DynamicParameters();
            parameter.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultGetAmenitiesByProductIdDto>(query, parameter);
                return values.ToList();
            }
        }
        public async Task<List<ResultGetAmenitiesByProductIdDto>> GetAmenitiesByProductIdTrue(int id)
        {
            string query = "Select *from ProductAmenity\r\ninner join Amenity on ProductAmenity.AmenityId = Amenity.AmenityId where ProductId = @ProductId and Status=1";
            var parameter = new DynamicParameters();
            parameter.Add("@ProductId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultGetAmenitiesByProductIdDto>(query, parameter);
                return values.ToList();
            }
        }
    }
}
