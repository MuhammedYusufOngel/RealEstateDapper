using Dapper;
using RealEstateDapperApi.Dtos.AboutDetailDtos;
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

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            string query = "Select *from Service";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }
    }
}
