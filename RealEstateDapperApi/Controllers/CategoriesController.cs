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
            var values = await _categoryRepository.GetAllCategories();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var value = await _categoryRepository.GetCategory(id);
            return Ok(value);
        }
    }
}
