using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.EmployeeDtos;
using RealEstateDapperUI.Dtos.ProductDetailDtos;
using RealEstateDapperUI.Dtos.ProductDtos;
using RealEstateDapperUI.Dtos.ProductImageDtos;

namespace RealEstateDapperUI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/ProductDetails/GetProductDetailById?id=" + id);
            var response2 = await client2.GetAsync("https://localhost:7195/api/ProductImages/GetProductImageByProductId?id=" + id);
            var jsonData = await response.Content.ReadAsStringAsync();
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultGetProductDetailByIdDto>(jsonData);
            var values2 = JsonConvert.DeserializeObject<List<ResultGetProductImageByIdDto>>(jsonData2);
            ViewBag.title1 = values.Title.ToString();
            ViewBag.BedroomCount = values.BedroomCount;
            ViewBag.BathCount = values.BathCount;
            ViewBag.RoomCount = values.RoomCount;
            ViewBag.Price = values.Price;
            ViewBag.Size = values.Size;
            ViewBag.GarageSize = values.GarageSize;
            ViewBag.BuildYear = values.BuildYear;
            ViewBag.Location = values.Location;
            ViewBag.VideoUrl = values.VideoUrl;
            ViewBag.Type = values.Type;
            ViewBag.Date = values.Date;
            ViewBag.Description = values.Description;
            ViewBag.CoverImage = values.CoverImage;
            ViewBag.ProductDetailId = values.ProductDetailId;
            ViewBag.City = values.City;
            ViewBag.District = values.District;
            ViewBag.Address = values.Address;
            ViewBag.Name = values.Name;
            ViewBag.EmployeeTitle = values.EmployeeTitle;
            ViewBag.PhoneNumber = values.PhoneNumber;
            ViewBag.Mail = values.Mail;
            ViewBag.ProfileUrl = values.ProfileUrl;

            var dateDiff = DateTime.Now - values.Date;

            if(dateDiff.Days == 0)
                ViewBag.Date = "Bugün";
            else
                ViewBag.Date = dateDiff.Days.ToString() + " gün önce";


            return View(values2);
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int categoryId, string city)
        {
            searchKeyValue = TempData["word"]?.ToString();
            categoryId = Convert.ToInt32(TempData["word1"].ToString());
            city = TempData["word2"].ToString();
            var client = _httpClientFactory.CreateClient();

            if(searchKeyValue == "")
            {
                var response = await client.GetAsync($"https://localhost:7195/api/Products/GetResultProductWithSearchWithoutSearch?&categoryId={categoryId}&city={city}");


                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchDto>>(jsonData);
                    return View(values);
                }
                return View();
            }
            else
            {
                var response = await client.GetAsync($"https://localhost:7195/api/Products/GetResultProductWithSearch?searchKeyValue={searchKeyValue}&categoryId={categoryId}&city={city}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchDto>>(jsonData);
                    return View(values);
                }
                return View();
            }
        }
                
    }
}
