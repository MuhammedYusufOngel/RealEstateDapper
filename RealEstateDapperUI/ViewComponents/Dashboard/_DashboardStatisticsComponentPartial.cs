using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.AccessControl;

namespace RealEstateDapperUI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region İstatistik1 - Toplam İlan Sayısı
            var client1 = _httpClientFactory.CreateClient();
            var response1 = await client1.GetAsync("https://localhost:7195/api/Statistics/ProductCount");
            var jsonData1 = await response1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            #endregion

            #region İstatistik2 - En İyi Personel
            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync("https://localhost:7195/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData2;
            #endregion

            #region İstatistik3 - İlandaki Şehir Sayısı
            var client3 = _httpClientFactory.CreateClient();
            var response3 = await client3.GetAsync("https://localhost:7195/api/Statistics/DifferentCityCount");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData3;
            #endregion

            #region İstatistik4 - Kira Ortalama Fiyat
            var client4 = _httpClientFactory.CreateClient();
            var response4 = await client4.GetAsync("https://localhost:7195/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceByRent = jsonData4;
            #endregion

            return View();
        }
    }
}
