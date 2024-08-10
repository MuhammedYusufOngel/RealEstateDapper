using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ProductDtos;
using RealEstateDapperUI.Services;

namespace RealEstateDapperUI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]   
    public class MyPastAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyPastAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Claims;
            var userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products/ProductAdvertsListByEmployeeIdFalse?id=" + userId);
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
