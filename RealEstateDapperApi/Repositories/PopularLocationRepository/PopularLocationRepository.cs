using Dapper;
using RealEstateDapperApi.Dtos.BottomGridDtos;
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

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (Name, ImageUrl) values (@Name, @ImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createPopularLocationDto.Name);
            parameters.Add("@ImageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete from PopularLocation where LocationId=@LocationId";
            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int id)
        {
            string query = "Select *from PopularLocation where LocationId=@LocationId";
            var parameter = new DynamicParameters();
            parameter.Add("@LocationId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameter);
                return values;
            }
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

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation set Name=@Name, ImageUrl=@ImageUrl where LocationId=@LocationId";
            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", updatePopularLocationDto.LocationId);
            parameters.Add("@Name", updatePopularLocationDto.Name);
            parameters.Add("@ImageUrl", updatePopularLocationDto.ImageUrl);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
