using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Dashboard
{
    public class _DashboardChartComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
