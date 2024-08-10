using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.PopularLocationDtos;
using RealEstateDapperApi.Repositories.PopularLocationRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularLocations()
        {
            var values = await _popularLocationRepository.GetAllPopularLocations();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            await _popularLocationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _popularLocationRepository.DeletePopularLocation(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPopularLocation(int id)
        {
            var value = await _popularLocationRepository.GetByIdPopularLocation(id);
            return Ok(value);
        }
    }
}
