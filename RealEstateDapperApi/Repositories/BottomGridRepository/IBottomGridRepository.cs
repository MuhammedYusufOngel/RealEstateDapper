using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Dtos.CategoryDtos;

namespace RealEstateDapperApi.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id);
    }
}
