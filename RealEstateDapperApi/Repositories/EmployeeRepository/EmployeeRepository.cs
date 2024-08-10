using Dapper;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Dtos.EmployeeDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status) values (@Name, @Title, @Mail, @PhoneNumber, @ImageUrl, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createEmployeeDto.Name);
            parameters.Add("@Title", createEmployeeDto.Title);
            parameters.Add("@Mail", createEmployeeDto.Mail);
            parameters.Add("@PhoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee set Name=@Name, Title=@Title, Mail=@Mail, PhoneNumber=@PhoneNumber, ImageUrl=@ImageUrl, Status=@Status where EmployeeId=@EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", updateEmployeeDto.EmployeeId);
            parameters.Add("@Name", updateEmployeeDto.Name);
            parameters.Add("@Title", updateEmployeeDto.Title);
            parameters.Add("@Mail", updateEmployeeDto.Mail);
            parameters.Add("@PhoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@Status", updateEmployeeDto.Status);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployees()
        {
            string query = "Select *from Employee";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployee(int id)
        {
            string query = "Select *from Employee where EmployeeId=@EmployeeId";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameter);
                return values;
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "Delete from Employee where EmployeeId=@EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
