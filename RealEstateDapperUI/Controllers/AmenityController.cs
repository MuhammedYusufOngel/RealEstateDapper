using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.AmenityDtos;
using RealEstateDapperUI.Dtos.ProductDtos;

namespace RealEstateDapperUI.Controllers
{
    [Authorize]
    public class AmenityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AmenityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7195/api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                ViewBag.name = values.Title;
                ViewBag.district = values.District;
                ViewBag.city = values.City;
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAmenitiesDto createAmenitiesDto)
        {
            return View();
        }
    }
}
