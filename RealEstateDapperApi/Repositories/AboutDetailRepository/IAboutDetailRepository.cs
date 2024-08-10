using RealEstateDapperApi.Dtos.AboutDetailDtos;

namespace RealEstateDapperApi.Repositories.AboutDetailRepository
{
    public interface IAboutDetailRepository
    {
        Task<List<ResultAboutDetailDto>> GetAllAboutDetail();
        Task CreateAboutDetail(CreateAboutDetailDto createAboutDetailDto);
        Task DeleteAboutDetail(int id);
        Task UpdateAboutDetail(UpdateAboutDetailDto updateAboutDetailDto);
        Task<GetByIdAboutDetailDto> GetByIdAboutDetail(int id);
    }
}
