using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.AdminLayout
{
    public class _AdminSpinnerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
