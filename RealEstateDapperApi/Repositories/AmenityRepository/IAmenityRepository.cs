using RealEstateDapperApi.Dtos.AmenityDtos;

namespace RealEstateDapperApi.Repositories.AmenityRepository
{
    public interface IAmenityRepository
    {
        Task<List<ResultGetAmenitiesByProductIdDto>> GetAmenitiesByProductId(int id);
        Task<List<ResultGetAmenitiesByProductIdDto>> GetAmenitiesByProductIdTrue(int id);
        Task<List<ResultAmenitiesDto>> GetAllAmenities();
        Task DoAmenityStatusTrue(int productid, int amenityid);
        Task DoAmenityStatusFalse(int productid, int amenityid);
    }
}
