using Microsoft.AspNetCore.Mvc;
using RealEstateDapperUI.Services;
using System.Net.Http;

namespace RealEstateDapperUI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            
            #region İstatistik1 - Toplam İlanlarım
            var client1 = _httpClientFactory.CreateClient();
            var response1 = await client1.GetAsync("https://localhost:7195/api/EstateAgentStatistic/ProductCountByEmployeeId?id="+ id);
            var jsonData1 = await response1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            #endregion

            #region İstatistik2 - Toplam İlan Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync("https://localhost:7195/api/EstateAgentStatistic/AllProductCount");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.AllProductCount = jsonData2;
            #endregion

            #region İstatistik3 - Aktif İlan
            var client3 = _httpClientFactory.CreateClient();
            var response3 = await client3.GetAsync("https://localhost:7195/api/EstateAgentStatistic/ProductCountByStatusTrue?id=" + id);
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.ProductCountTrue = jsonData3;
            #endregion

            #region İstatistik4 - Pasif İlan
            var client4 = _httpClientFactory.CreateClient();
            var response4 = await client4.GetAsync("https://localhost:7195/api/EstateAgentStatistic/ProductCountByStatusFalse?id=" + id);
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.ProductCountFalse = jsonData4;
            #endregion

            return View();
        }
    }
}
