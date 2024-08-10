using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Dtos.CategoryDtos;

namespace RealEstateDapperApi.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGrid();
        Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        Task DeleteBottomGrid(int id);
        Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id);
    }
}
