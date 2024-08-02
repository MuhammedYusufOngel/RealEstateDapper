using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ProductDtos;
using System.Net.Http;

namespace RealEstateDapperUI.ViewComponents.EstateAgent
{
    public class _EstateAgentSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
