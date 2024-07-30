using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.PopularLocationRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularLocations()
        {
            var values = await _popularLocationRepository.GetPopularLocationAsync();
            return Ok(values);
        }
    }
}
