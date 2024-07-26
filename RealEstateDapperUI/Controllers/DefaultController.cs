using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
