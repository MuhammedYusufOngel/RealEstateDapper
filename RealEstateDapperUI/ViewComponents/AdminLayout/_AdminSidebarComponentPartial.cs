using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.EmployeeDtos;
using RealEstateDapperUI.Services;
using System.Net.Http;

namespace RealEstateDapperUI.ViewComponents.AdminLayout
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _AdminSidebarComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
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
            return View();
        }
    }
}
