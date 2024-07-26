using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.AboutDetailDtos;

namespace RealEstateDapperUI.ViewComponents.HomePage
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/AboutDetail");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDetailDto>>(jsonData);
                ViewBag.Title = values.Select(x => x.Title).FirstOrDefault();
                ViewBag.Subtitle = values.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.Description1 = values.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = values.Select(x => x.Description2).FirstOrDefault();
                return View(values);
            }
            return View();
        }
    }
}
