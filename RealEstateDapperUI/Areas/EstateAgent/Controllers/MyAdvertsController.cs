using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.CategoryDtos;
using RealEstateDapperUI.Dtos.ProductDtos;
using RealEstateDapperUI.Services;

namespace RealEstateDapperUI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products/ProductAdvertsListByEmployeeIdTrue?id=" + userId);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGetByEmployeeIdProductsDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);


                List<SelectListItem> categoryValues = (from x in values.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();


                List<SelectListItem> typeValues = new List<SelectListItem>()
                {
                    new SelectListItem
                    {
                        Text = "Satılık",
                        Value = "Satılık"
                    },
                    new SelectListItem
                    {
                        Text = "Kiralık",
                        Value = "Kiralık"
                    },
                };

                ViewBag.v = categoryValues;
                ViewBag.type = typeValues;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto)
        {
            createProductDto.EmployeeId = Convert.ToInt32(_loginService.GetUserId);
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7195/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createProductDto);
        }
    }
}
