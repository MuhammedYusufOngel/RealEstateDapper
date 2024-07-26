using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.HomePage
{
    public class _DefaultOurClientsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
