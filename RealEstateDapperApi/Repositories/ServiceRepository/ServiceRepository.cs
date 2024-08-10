using Dapper;
using RealEstateDapperApi.Dtos.ServiceDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateService(CreateServiceDto createServiceDto)
        {
            string query = "insert into Service (Name, Status) values (@Name, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createServiceDto.Name);
            parameters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteService(int id)
        {
            string query = "Delete from Service where ServiceId=@ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            string query = "Select *from Service";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetByIdService(int id)
        {
            string query = "Select *from Service where ServiceId=@ServiceId";
            var parameter = new DynamicParameters();
            parameter.Add("@ServiceId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameter);
                return values;
            }
        }

        public async Task UpdateService(UpdateServiceDto updateServiceDto)
        {
            string query = "Update Service set Name=@Name, Status=@Status where ServiceId=@ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", updateServiceDto.ServiceId);
            parameters.Add("@Name", updateServiceDto.Name);
            parameters.Add("@Status", updateServiceDto.Status);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
