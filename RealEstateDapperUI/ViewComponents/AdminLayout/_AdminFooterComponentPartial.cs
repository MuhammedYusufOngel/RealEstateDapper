using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.AdminLayout
{
    public class _AdminFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
