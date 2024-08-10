using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Dtos.PopularLocationDtos;

namespace RealEstateDapperApi.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocations();
        Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        Task DeletePopularLocation(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
        Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int id);
    }
}
