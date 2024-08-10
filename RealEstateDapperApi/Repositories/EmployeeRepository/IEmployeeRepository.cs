using RealEstateDapperApi.Dtos.EmployeeDtos;

namespace RealEstateDapperApi.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployees();
        Task CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task<GetByIdEmployeeDto> GetEmployee(int id);
    }
}
