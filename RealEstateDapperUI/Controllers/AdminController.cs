using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
