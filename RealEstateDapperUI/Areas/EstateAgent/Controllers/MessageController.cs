using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.EmployeeDtos;
using RealEstateDapperUI.Dtos.MessageDtos;
using RealEstateDapperUI.Services;
using System.Net.Http;

namespace RealEstateDapperUI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MessageController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7195/api/Messages/GetAllMessagesByUserId?id={userId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByUserIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> IncomingMessages()
        {
            var userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7195/api/Messages/GetAllSentMessagesByUserId?id={userId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByUserIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMessage()
        {
            var userId = _loginService.GetUserId;


            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/Employees");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);

                var senderId = values.FirstOrDefault(item => item.EmployeeId == Convert.ToInt32(userId));
                
                if (senderId != null)
                {
                    values.Remove(senderId);
                }

                List<SelectListItem> employeeValues = (from x in values.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.EmployeeId.ToString()
                                                       }).ToList();
                ViewBag.e = employeeValues;
                ViewBag.sender = senderId.EmployeeId;
                ViewBag.id = userId;
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            var userId = _loginService.GetUserId;

            createMessageDto.SenderId = userId;
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7195/api/Messages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SentMessages");
            }
            return View();
        }
    }
}
