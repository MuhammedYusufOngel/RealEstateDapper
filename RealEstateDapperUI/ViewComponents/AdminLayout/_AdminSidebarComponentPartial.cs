using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.AdminLayout
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
