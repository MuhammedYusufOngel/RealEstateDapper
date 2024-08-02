using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Tools;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateToken(GetCheckAppUserViewModel model)
        {
            var values = JwtTokenGenerator.GeneratorToken(model);
            return Ok(values);
        }
    }
}
