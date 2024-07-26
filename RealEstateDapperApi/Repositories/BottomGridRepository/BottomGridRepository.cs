using Dapper;
using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    {

        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select *from BottomGrid";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }
    }
}
