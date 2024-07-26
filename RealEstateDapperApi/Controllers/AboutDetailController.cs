using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Repositories.AboutDetailRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutDetailController : ControllerBase
    {
        private readonly IAboutDetailRepository _aboutDetailRepository;

        public AboutDetailController(IAboutDetailRepository aboutDetailRepository)
        {
            _aboutDetailRepository = aboutDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutDetail()
        {
            var values = await _aboutDetailRepository.GetAllAboutDetailAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutDetail(CreateAboutDetailDto createAboutDetailDto)
        {
            _aboutDetailRepository.CreateAboutDetail(createAboutDetailDto);
            return Ok("Kategori başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAboutDetail(int id)
        {
            _aboutDetailRepository.DeleteAboutDetail(id);
            return Ok("İşlem başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAboutDetail(UpdateAboutDetailDto updateAboutDetailDto)
        {
            _aboutDetailRepository.UpdateAboutDetail(updateAboutDetailDto);
            return Ok("İşlem başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAboutDetail(int id)
        {
            var value = await _aboutDetailRepository.GetByIdAboutDetail(id);
            return Ok(value);
        }
    }
}
