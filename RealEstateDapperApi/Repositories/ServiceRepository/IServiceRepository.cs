using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Dtos.ServiceDtos;

namespace RealEstateDapperApi.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServicesAsync();
        Task CreateService(CreateServiceDto createServiceDto);
        Task DeleteService(int id);
        Task UpdateService(UpdateServiceDto updateServiceDto);
        Task<GetByIdServiceDto> GetByIdService(int id);
    }
}
