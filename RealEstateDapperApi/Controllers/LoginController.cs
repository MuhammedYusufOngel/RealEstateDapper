using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.LoginDtos;
using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Tools;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto) 
        {
            string query = "Select *from AppUser where Username=@Username and Password=@Password";
            var parameters = new DynamicParameters();
            parameters.Add("@Username", createLoginDto.Username);
            parameters.Add("@Password", createLoginDto.Password);
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                if(values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.Id = values.UserId;
                    var result = JwtTokenGenerator.GeneratorToken(model);
                    return Ok(result);
                }
                else
                {
                    return Ok("👎");
                }
            }
        }
    }
}
