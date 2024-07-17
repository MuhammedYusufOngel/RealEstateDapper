using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Repositories.CategoryRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryResult()
        {
            var values = await _categoryRepository.GetAllCategorySync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("İşlem başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("İşlem başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var value = await _categoryRepository.GetCategory(id);
            return Ok(value);
        }
    }
}
