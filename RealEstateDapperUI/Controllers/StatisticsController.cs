using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstateDapperUI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region İstatistik1
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Statistics/ActiveCategoryCount");
            var jsonData = await response.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount = jsonData;
            #endregion

            #region İstatistik2
            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync("https://localhost:7195/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonData2;
            #endregion

            #region İstatistik3
            var client3 = _httpClientFactory.CreateClient();
            var response3 = await client3.GetAsync("https://localhost:7195/api/Statistics/ApartmantCount");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.ApartmantCount = jsonData3;
            #endregion

            #region İstatistik4
            var client4 = _httpClientFactory.CreateClient();
            var response4 = await client4.GetAsync("https://localhost:7195/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceByRent = jsonData4;
            #endregion

            #region İstatistik5
            var client5 = _httpClientFactory.CreateClient();
            var response5 = await client5.GetAsync("https://localhost:7195/api/Statistics/AverageProductPriceBySale");
            var jsonData5 = await response5.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceBySale = jsonData5;
            #endregion

            #region İstatistik6
            var client6 = _httpClientFactory.CreateClient();
            var response6 = await client6.GetAsync("https://localhost:7195/api/Statistics/AverageRoomCount");
            var jsonData6 = await response6.Content.ReadAsStringAsync();
            ViewBag.AverageRoomCount = jsonData6;
            #endregion

            #region İstatistik7
            var client7 = _httpClientFactory.CreateClient();
            var response7 = await client7.GetAsync("https://localhost:7195/api/Statistics/CategoryCount");
            var jsonData7 = await response7.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData7;
            #endregion

            #region İstatistik8
            var client8 = _httpClientFactory.CreateClient();
            var response8 = await client8.GetAsync("https://localhost:7195/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await response8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonData8;
            #endregion

            #region İstatistik9
            var client9 = _httpClientFactory.CreateClient();
            var response9 = await client9.GetAsync("https://localhost:7195/api/Statistics/CityNameByMaxProductCount");
            var jsonData9 = await response9.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonData9;
            #endregion

            #region İstatistik10
            var client10 = _httpClientFactory.CreateClient();
            var response10 = await client10.GetAsync("https://localhost:7195/api/Statistics/DifferentCityCount");
            var jsonData10 = await response10.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData10;
            #endregion

            #region İstatistik11
            var client11 = _httpClientFactory.CreateClient();
            var response11 = await client11.GetAsync("https://localhost:7195/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData11 = await response11.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData11;
            #endregion

            #region İstatistik12
            var client12 = _httpClientFactory.CreateClient();
            var response12 = await client12.GetAsync("https://localhost:7195/api/Statistics/LastProductPrice");
            var jsonData12 = await response12.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData12;
            #endregion

            #region İstatistik13
            var client13 = _httpClientFactory.CreateClient();
            var response13 = await client13.GetAsync("https://localhost:7195/api/Statistics/NewestBuilding");
            var jsonData13 = await response13.Content.ReadAsStringAsync();
            ViewBag.NewestBuilding = jsonData13;
            #endregion

            #region İstatistik14
            var client14 = _httpClientFactory.CreateClient();
            var response14 = await client14.GetAsync("https://localhost:7195/api/Statistics/OldestBuilding");
            var jsonData14 = await response14.Content.ReadAsStringAsync();
            ViewBag.OldestBuilding = jsonData14;
            #endregion

            #region İstatistik15
            var client15 = _httpClientFactory.CreateClient();
            var response15 = await client15.GetAsync("https://localhost:7195/api/Statistics/PassiveCategoryCount");
            var jsonData15 = await response15.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonData15;
            #endregion

            #region İstatistik16
            var client16 = _httpClientFactory.CreateClient();
            var response16 = await client16.GetAsync("https://localhost:7195/api/Statistics/ProductCount");
            var jsonData16 = await response16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData16;
            #endregion

            return View();

        }
    }
}
