using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.EmployeeDtos;
using RealEstateDapperApi.Repositories.EmployeeRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var values = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            _employeeRepository.CreateEmployee(createEmployeeDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdEmployee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            return Ok(value);
        }
    }
}
