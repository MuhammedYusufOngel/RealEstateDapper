using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ProductDtos;
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
            await _productRepository.CreateProduct(createProductDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productRepository.UpdateProduct(updateProductDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var values = await _productRepository.GetByIdProduct(id);
            return Ok(values);
        }

        [HttpGet("ProductDealOfTheDayChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToTrue(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("👍");
        }

        [HttpGet("ProductDealOfTheDayChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToFalse(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("👍");
        }

        [HttpGet("ProductStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductStatusChangeToTrue(int id)
        {
            await _productRepository.ProductStatusChangeToTrue(id);
            return Ok("👍");
        }

        [HttpGet("ProductStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductStatusChangeToFalse(int id)
        {
            await _productRepository.ProductStatusChangeToFalse(id);
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

        [HttpGet("ProductAdvertsListByEmployeeIdTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeIdTrue(int id)
        {
            var values = await _productRepository.GetByEmployeeIdProductsTrueAsync(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployeeIdFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeIdFalse(int id)
        {
            var values = await _productRepository.GetByEmployeeIdProductsFalseAsync(id);
            return Ok(values);
        }

        [HttpGet("GetResultProductWithSearch")]
        public async Task<IActionResult> GetResultProductWithSearch(string searchKeyValue, int categoryId, string city)
        {
            var values = await _productRepository.GetResultProductWithSearch(searchKeyValue, categoryId, city);
            return Ok(values);
        }

        [HttpGet("GetResultProductWithSearchWithoutSearch")]
        public async Task<IActionResult> GetResultProductWithSearchWithoutSearch(int categoryId, string city)
        {
            var values = await _productRepository.GetResultProductWithSearch(categoryId, city);
            return Ok(values);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("GetLast3Product")]
        public async Task<IActionResult> GetLast3Product()
        {
            var values = await _productRepository.GetLast3ProductAsync();
            return Ok(values);
        }

        [HttpGet("GetLastProduct")]
        public async Task<IActionResult> GetLastProduct()
        {
            var value = await _productRepository.GetLastProduct();
            return Ok(value);
        }
    }
}
