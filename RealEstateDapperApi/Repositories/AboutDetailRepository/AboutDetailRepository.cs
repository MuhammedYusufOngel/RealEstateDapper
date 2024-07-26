using Dapper;
using RealEstateDapperApi.Dtos.AboutDetailDtos;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.AboutDetailRepository
{
    public class AboutDetailRepository : IAboutDetailRepository
    {
        Context _context;

        public AboutDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateAboutDetail(CreateAboutDetailDto createAboutDetailDto)
        {
            string query = "insert into AboutDetail (Title, Subtitle, Description1, Description2) values (@Title, @Subtitle, @Description1, @Description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createAboutDetailDto.Title);
            parameters.Add("@Subtitle", createAboutDetailDto.Subtitle);
            parameters.Add("@Description1", createAboutDetailDto.Description1);
            parameters.Add("@Description2", createAboutDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteAboutDetail(int id)
        {
            string query = "Delete from AboutDetail where AboutId=@AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@AboutId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdAboutDetailDto> GetByIdAboutDetail(int id)
        {
            string query = "Select *from AboutDetail where AboutId=@AboutId";
            var parameter = new DynamicParameters();
            parameter.Add("@AboutId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdAboutDetailDto>(query, parameter);
                return values;
            }
        }

        public async Task<List<ResultAboutDetailDto>> GetAllAboutDetailAsync()
        {
            var query = "Select *from AboutDetail";
            using(var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultAboutDetailDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateAboutDetail(UpdateAboutDetailDto updateAboutDetailDto)
        {
            string query = "Update AboutDetail set Title=@Title, Subtitle=@Subtitle, Description1=@Description1, Description2=@Description2 where AboutId=@AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@AboutId", updateAboutDetailDto.AboutId);
            parameters.Add("@Title", updateAboutDetailDto.Title);
            parameters.Add("@Subtitle", updateAboutDetailDto.Subtitle);
            parameters.Add("@Description1", updateAboutDetailDto.Description1);
            parameters.Add("@Description2", updateAboutDetailDto.Description2);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
