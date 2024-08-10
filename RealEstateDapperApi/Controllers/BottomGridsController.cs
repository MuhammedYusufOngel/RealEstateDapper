using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Repositories.BottomGridRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBottomGrids()
        {
            var values = await _bottomGridRepository.GetAllBottomGrid();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetByIdBottomGrid(id);
            return Ok(value);
        }
    }
}
