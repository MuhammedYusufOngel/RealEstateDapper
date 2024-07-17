using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstateDapperApi.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connection);
    }
}
