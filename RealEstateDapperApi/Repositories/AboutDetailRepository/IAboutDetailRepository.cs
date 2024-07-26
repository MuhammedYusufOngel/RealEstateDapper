using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Dtos.CategoryDtos;

namespace RealEstateDapperApi.Repositories.AboutDetailRepository
{
    public interface IAboutDetailRepository
    {
        Task<List<ResultAboutDetailDto>> GetAllAboutDetailAsync();
        void CreateAboutDetail(CreateAboutDetailDto createAboutDetailDto);
        void DeleteAboutDetail(int id);
        void UpdateAboutDetail(UpdateAboutDetailDto updateAboutDetailDto);
        Task<GetByIdAboutDetailDto> GetByIdAboutDetail(int id);
    }
}
