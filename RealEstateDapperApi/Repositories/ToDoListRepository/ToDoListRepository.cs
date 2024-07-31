using Dapper;
using RealEstateDapperApi.Dtos.ToDoListDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ToDoListRepository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async void CreateToDo(CreateToDoListDto createToDoListDto)
        {
            string query = "insert into ToDoList (Description, Status) values (@Description, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Description", createToDoListDto.Description);
            parameters.Add("@Status", createToDoListDto.Status);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteToDo(int id)
        {
            string query = "Delete from ToDoList where ToDoListId=@ToDoListId";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdToDoListDto> GetToDo(int id)
        {
            string query = "Select *from ToDoList where ToDoListId=@ToDoListId";
            var parameter = new DynamicParameters();
            parameter.Add("@ToDoListId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdToDoListDto>(query, parameter);
                return values;
            }
        }

        public async Task<List<ResultToDoListDto>> GetToDoListAsync()
        {
            string query = "Select *from ToDoList";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateToDo(UpdateToDoListDto updateToDoListDto)
        {
            string query = "Update ToDoList set Description=@Description, Status=@Status where ToDoListId=@ToDoListId";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListId", updateToDoListDto.ToDoListId);
            parameters.Add("@Description", updateToDoListDto.Description);
            parameters.Add("@Status", updateToDoListDto.Status);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
