using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Dtos.PopularLocationDtos;

namespace RealEstateDapperApi.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetPopularLocationAsync();
        void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
        Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int id);
    }
}
