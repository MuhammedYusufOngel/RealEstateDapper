using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Dtos.ServiceDtos;

namespace RealEstateDapperApi.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServicesAsync();
        void CreateService(CreateServiceDto createServiceDto);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto updateServiceDto);
        Task<GetByIdServiceDto> GetByIdService(int id);
    }
}
