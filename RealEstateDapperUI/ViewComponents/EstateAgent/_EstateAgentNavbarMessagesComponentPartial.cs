using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.MessageDtos;
using RealEstateDapperUI.Services;

namespace RealEstateDapperUI.ViewComponents.EstateAgent
{
    public class _EstateAgentNavbarMessagesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentNavbarMessagesComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Messages/GetAllMessagesByUserId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByUserIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
