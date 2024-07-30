using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Dtos.PopularLocationDtos;

namespace RealEstateDapperApi.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetPopularLocationAsync();
    }
}
