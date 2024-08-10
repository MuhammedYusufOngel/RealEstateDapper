using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.AmenityDtos;
    
namespace RealEstateDapperUI.ViewComponents.Property
{
    public class _PropertyAmenitiesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenitiesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Amenities/GetAmenitiesByProductIdTrue?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGetAmenitiesByProductIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
