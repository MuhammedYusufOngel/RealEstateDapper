using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1()
        {
            return View();
        }
    }
}
