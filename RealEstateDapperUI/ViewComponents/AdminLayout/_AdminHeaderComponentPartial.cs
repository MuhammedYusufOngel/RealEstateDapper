using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.AdminLayout
{
    public class _AdminHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}