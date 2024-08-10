using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartsController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartsController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet("Get5CityForChart")]
        public async Task<IActionResult> Get5CityForChart()
        {
            return Ok(await _chartRepository.Get5CityForChart());
        }
    }
}
