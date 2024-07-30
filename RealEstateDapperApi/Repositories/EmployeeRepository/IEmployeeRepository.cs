using RealEstateDapperApi.Dtos.EmployeeDtos;

namespace RealEstateDapperApi.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        void CreateEmployee(CreateEmployeeDto createEmployeeDto);
        void DeleteEmployee(int id);
        void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task<GetByIdEmployeeDto> GetEmployee(int id);
    }
}
