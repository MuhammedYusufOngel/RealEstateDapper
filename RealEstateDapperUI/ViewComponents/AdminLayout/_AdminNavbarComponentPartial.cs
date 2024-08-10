using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ContactDtos;
using RealEstateDapperUI.Dtos.EmployeeDtos;
using RealEstateDapperUI.Models;
using RealEstateDapperUI.Services;

namespace RealEstateDapperUI.ViewComponents.AdminLayout
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _AdminNavbarComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7195/api/Login/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultEmployeeWithAppUserDto>(jsonData);
                ViewBag.image = values.ImageUrl;
                ViewBag.name = values.UserName;
            }

            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync($"https://localhost:7195/api/Contacts/GetLast4Contacts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData2);
                return View(values2);
            }
            return View();
        }
    }
}
