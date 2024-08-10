using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.AmenityDtos;
using RealEstateDapperApi.Dtos.ProductDetailDtos;
using RealEstateDapperApi.Repositories.ProductDetailRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailsController(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var values = await _productDetailRepository.GetAllProductDetails();
            return Ok(values);
        }

        [HttpGet("GetProductDetailById")]
        public async Task<IActionResult> GetProductDetailById(int id)
        {
            var productDetail = await _productDetailRepository.GetProductDetailById(id);
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
                await _productDetailRepository.CreateProductDetail(createProductDetailDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            await _productDetailRepository.DeleteProductDetail(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailRepository.UpdateProductDetail(updateProductDetailDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetailForUpdate(int id)
        {
            var values = await _productDetailRepository.GetByIdProductDetailForUpdate(id);
            return Ok(values);
        }
    }
}
