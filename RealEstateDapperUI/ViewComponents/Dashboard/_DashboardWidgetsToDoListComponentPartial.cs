using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ToDoListDtos;

namespace RealEstateDapperUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetsToDoListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}