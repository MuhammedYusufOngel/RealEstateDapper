using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ProductImageDtos;
using RealEstateDapperApi.Repositories.ProductImageRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImagesController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageRepository.CreateProductImage(createProductImageDto);
            return Ok("👍");
        }

        [HttpGet("GetProductImageByProductId")]
        public async Task<IActionResult> GetProductImageByProductId(int id)
        {
            var values = await _productImageRepository.GetProductImageByProductId(id);
            return Ok(values);
        }
    }
}
