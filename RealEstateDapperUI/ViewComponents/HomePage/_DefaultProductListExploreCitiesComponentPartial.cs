using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.PopularLocationDtos;
using System.Net.Http;

namespace RealEstateDapperUI.ViewComponents.HomePage
{
    public class _DefaultProductListExploreCitiesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/PopularLocation");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
