using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;
using System.Diagnostics.Contracts;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentStatisticsController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public EstateAgentStatisticsController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statisticRepository.AllProductCount());
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusTrue(id));
        }
    }
}
