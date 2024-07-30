using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.BottomGridDtos;

namespace RealEstateDapperUI.Controllers
{
    public class BottomGridController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BottomGridController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/BottomGrid");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateBottomGridElement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGridElement(CreateBottomGridDto createBottomGridDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBottomGridDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7195/api/BottomGrid", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBottomGridElement(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7195/api/BottomGrid/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBottomGrid(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7195/api/BottomGrid/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBottomGridDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBottomGridDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7195/api/BottomGrid/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
