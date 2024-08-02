using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ProductDtos;
using System.Net.Http;

namespace RealEstateDapperUI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyAdvertsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products/ProductAdvertsListByEmployeeId?id="+ id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGetByEmployeeIdProductsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
