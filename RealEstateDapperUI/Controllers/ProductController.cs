using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.CategoryDtos;
using RealEstateDapperUI.Dtos.EmployeeDtos;
using RealEstateDapperUI.Dtos.ProductDtos;
using RealEstateDapperUI.Dtos.ProductImageDtos;

namespace RealEstateDapperUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
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
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Categories");
            var response2 = await client.GetAsync("https://localhost:7195/api/Employees");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                var values2 = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData2);


                List<SelectListItem> categoryValues = (from x in values.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();


                List<SelectListItem> employeeValues = (from x in values2.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.EmployeeId.ToString()
                                                       }).ToList();

                ViewBag.v = categoryValues;
                ViewBag.e = employeeValues;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7195/api/Products", content);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var client2 = _httpClientFactory.CreateClient();
                var response2 = await client2.GetAsync("https://localhost:7195/api/Products/GetLastProduct");
                if(response2.IsSuccessStatusCode)
                {
                    var jsonData2 = await response2.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultLastProductDto>(jsonData2);
                    return RedirectToAction("CreateProductDetail", new RouteValueDictionary(new { controller = "ProductDetail", action = "CreateProductDetail", Id = values.ProductId }));
                }
                
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7195/api/ProductDetails/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.DeleteAsync($"https://localhost:7195/api/Products/{id}");
                if (responseMessage2.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Categories");
            var response2 = await client.GetAsync("https://localhost:7195/api/Employees");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                var values2 = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData2);


                List<SelectListItem> categoryValues = (from x in values.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();


                List<SelectListItem> employeeValues = (from x in values2.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.EmployeeId.ToString()
                                                       }).ToList();

                ViewBag.v = categoryValues;
                ViewBag.e = employeeValues;
            }


            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync($"https://localhost:7195/api/Products/{id}");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData3);
                return View(values3);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7195/api/Products/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpGet("ProductDealOfTheDayChangeToTrue")]
        public async Task<IActionResult> GetActive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products/ProductDealOfTheDayChangeToTrue/"+id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpGet("ProductDealOfTheDayChangeToFalse")]
        public async Task<IActionResult> GetPassive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products/ProductDealOfTheDayChangeToFalse/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> GetActiveStatus(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products/ProductStatusChangeToTrue/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> GetPassiveStatus(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products/ProductStatusChangeToFalse/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddProductImage()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);


                List<SelectListItem> productValues = (from x in values.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Title,
                                                           Value = x.ProductId.ToString()
                                                       }).ToList();

                ViewBag.p = productValues;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductImage(CreateProductImageDto createProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductImageDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7195/api/ProductImages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
