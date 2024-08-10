using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.CategoryDtos;
using RealEstateDapperUI.Dtos.ProductDtos;
using System.Net.Http;

namespace RealEstateDapperUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Categories");
            var response2 = await client2.GetAsync("https://localhost:7195/api/Products");
            var jsonData = await response.Content.ReadAsStringAsync();
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            var values2 = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData2);


            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();


            List<SelectListItem> cityValues = (from x in values2.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.City,
                                                       Value = x.City.ToString()
                                                   }).ToList();

            ViewBag.v = categoryValues;
            ViewBag.c = cityValues;

            return View();
        }

        [HttpGet]
        public PartialViewResult PartialSearch()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialSearch(string searchKeyValue, int categoryId, string City)
        {
            if (searchKeyValue == null)
                TempData["word"] = "";

            else
                TempData["word"] = searchKeyValue;
            TempData["word1"] = categoryId;
            TempData["word2"] = City;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
