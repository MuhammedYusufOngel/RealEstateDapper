using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ServiceDtos;
using RealEstateDapperApi.Repositories.ServiceRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var values = await _serviceRepository.GetAllServicesAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceRepository.CreateService(createServiceDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteService(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateService(updateServiceDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdService(int id)
        {
            var value = await _serviceRepository.GetByIdService(id);
            return Ok(value);
        }
    }
}
