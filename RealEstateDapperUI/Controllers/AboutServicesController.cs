using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.AboutDetailDtos;

namespace RealEstateDapperUI.Controllers
{
    public class AboutServicesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutServicesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Services");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServicesDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServicesDto createServicesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServicesDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7195/api/Services", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7195/api/Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7195/api/Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServicesDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServicesDto updateServicesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServicesDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7195/api/Services/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
