using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Repositories.AboutDetailRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutDetailsController : ControllerBase
    {
        private readonly IAboutDetailRepository _aboutDetailRepository;

        public AboutDetailsController(IAboutDetailRepository aboutDetailRepository)
        {
            _aboutDetailRepository = aboutDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutDetail()
        {
            var values = await _aboutDetailRepository.GetAllAboutDetail();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutDetailAsync(CreateAboutDetailDto createAboutDetailDto)
        {
            await _aboutDetailRepository.CreateAboutDetail(createAboutDetailDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutDetailAsync(int id)
        {
            await _aboutDetailRepository.DeleteAboutDetail(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAboutDetailAsync(UpdateAboutDetailDto updateAboutDetailDto)
        {
            await _aboutDetailRepository.UpdateAboutDetail(updateAboutDetailDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAboutDetail(int id)
        {
            var value = await _aboutDetailRepository.GetByIdAboutDetail(id);
            return Ok(value);
        }
    }
}
