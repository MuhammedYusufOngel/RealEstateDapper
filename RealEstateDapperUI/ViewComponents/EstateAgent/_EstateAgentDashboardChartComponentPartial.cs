using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.EstateAgentChartDtos;

namespace RealEstateDapperUI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardChartComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/EstateAgentCharts/Get5CityForChart");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
