using Dapper;
using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Repositories.StatisticsRepository;

namespace RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int AllProductCount()
        {
            string query = "Select Count(*) from Product";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCountByEmployeeId(int id)
        {
            string query = "Select Count(*) from Product where EmployeeId=@EmployeeId";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query, parameter);
                return value;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) from Product where EmployeeId=@EmployeeId and Status=0";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query, parameter);
                return value;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) from Product where EmployeeId=@EmployeeId and Status=1";
            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query, parameter);
                return value;
            }
        }
    }
}
