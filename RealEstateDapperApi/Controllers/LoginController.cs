using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Dtos.LoginDtos;
using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Tools;
using System.Reflection.Metadata;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            string query = "Select *from AppUser " +
                "inner join Employee on AppUser.EmployeeId = Employee.EmployeeId " +
                "inner join AppRole on AppUser.UserRole = AppRole.RoleId " +
                "where UserId=@UserId";
            var parameter = new DynamicParameters();
            parameter.Add("@UserId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<ResultLoginDto>(query, parameter);
                return Ok(values);
            }
        }

        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn(string username, string password) 
        {
            string query = "Select *from AppUser where Username=@Username and Password=@Password";
            var parameters = new DynamicParameters();
            parameters.Add("@Username", username);
            parameters.Add("@Password", password);
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                if(values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.Id = values.UserId;
                    model.Role = values.UserRole.ToString();
                    var result = JwtTokenGenerator.GeneratorToken(model);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}
