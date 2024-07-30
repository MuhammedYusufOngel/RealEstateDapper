using Dapper;
using RealEstateDapperApi.Dtos.PopularLocationDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDto>> GetPopularLocationAsync()
        {
            string query = "Select *from PopularLocation";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }
    }
}
