using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ProductDtos;
using RealEstateDapperApi.Repositories.CategoryRepository;
using RealEstateDapperApi.Repositories.ProductRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductResult()
        {
            var values = await _productRepository.GetAllProductWithAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            _productRepository.CreateProduct(createProductDto);
            return Ok("Kategori başarılı şekilde eklendi");
        }

        [HttpGet("ProductDealOfTheDayChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("👍");
        }

        [HttpGet("ProductDealOfTheDayChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("👍");
        }

        [HttpGet("GetLast5Products")]
        public async Task<IActionResult> GetLast5Products()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }

        [HttpGet("GetLast5ProductByEmployeeId")]
        public async Task<IActionResult> GetLast5ProductByEmployeeId(int id)
        {
            var values = await _productRepository.GetLast5ProductByEmployeeIdAsync(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployeeId")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeId(int id)
        {
            var values = await _productRepository.GetByEmployeeIdProductsAsync(id);
            return Ok(values);
        }
    }
}
