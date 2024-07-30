using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.AdminLayout
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
