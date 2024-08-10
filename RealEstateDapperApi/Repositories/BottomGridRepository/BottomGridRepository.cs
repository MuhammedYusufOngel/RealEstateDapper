using Dapper;
using RealEstateDapperApi.Dtos.AboutDetailDtos;
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

        public async Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon, Title, Description) values (@Icon, @Title, @Description)";
            var parameters = new DynamicParameters();
            parameters.Add("@Icon", createBottomGridDto.Icon);
            parameters.Add("@Title", createBottomGridDto.Title);
            parameters.Add("@Description", createBottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            string query = "Delete from BottomGrid where BottomGridId=@BottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@BottomGridId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGrid()
        {
            string query = "Select *from BottomGrid";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id)
        {
            string query = "Select *from BottomGrid where BottomGridId=@BottomGridId";
            var parameter = new DynamicParameters();
            parameter.Add("@BottomGridId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, parameter);
                return values;
            }
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid set Icon=@Icon, Title=@Title, Description=@Description where BottomGridId=@BottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@BottomGridId", updateBottomGridDto.BottomGridId);
            parameters.Add("@Icon", updateBottomGridDto.Icon);
            parameters.Add("@Title", updateBottomGridDto.Title);
            parameters.Add("@Description", updateBottomGridDto.Description);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
