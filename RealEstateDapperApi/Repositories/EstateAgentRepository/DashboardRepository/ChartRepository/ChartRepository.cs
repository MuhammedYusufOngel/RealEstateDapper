using Dapper;
using RealEstateDapperApi.Dtos.ChartDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChart()
        {
            string query = "Select Top(5) City, Count(*) as 'CityCount' From Product Group By City order by CityCount Desc";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            } 
        }
    }
}
