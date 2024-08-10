using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.AmenityDtos;
using RealEstateDapperApi.Repositories.AmenityRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenityRepository _amenityRepository;

        public AmenitiesController(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAmenities()
        {
            var values = await _amenityRepository.GetAllAmenities();
            return Ok(values);
        }

        [HttpGet("GetAmenitiesByProductId")]
        public async Task<IActionResult> GetAmenitiesByProductId(int id)
        {
            var values = await _amenityRepository.GetAmenitiesByProductId(id);
            return Ok(values);
        }

        [HttpGet("GetAmenitiesByProductIdTrue")]
        public async Task<IActionResult> GetAmenitiesByProductIdTrue(int id)
        {
            var values = await _amenityRepository.GetAmenitiesByProductIdTrue(id);
            return Ok(values);
        }

        [HttpGet("DoAmenityStatusTrue")]
        public async Task<IActionResult> DoAmenityStatusTrue(int productid, int amenityid)
        {
            await _amenityRepository.DoAmenityStatusTrue(productid, amenityid);
            return Ok("OK");
        }

        [HttpGet("DoAmenityStatusFalse")]
        public async Task<IActionResult> DoAmenityStatusFalse(int productid, int amenityid)
        {
            await _amenityRepository.DoAmenityStatusFalse(productid, amenityid);
            return Ok("OK");
        }
    }
}
