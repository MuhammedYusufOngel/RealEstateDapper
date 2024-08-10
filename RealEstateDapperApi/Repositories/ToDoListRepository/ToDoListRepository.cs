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

        public async Task CreateToDo(CreateToDoListDto createToDoListDto)
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

        public async Task DeleteToDo(int id)
        {
            string query = "Delete from ToDoList where ToDoListId=@ToDoListId";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
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

        public async Task UpdateToDoStatusTrue(int id)
        {
            string query = "Update ToDoList set Status=1 where ToDoListId=@ToDoListId";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateToDoStatusFalse(int id)
        {
            string query = "Update ToDoList set Status=0 where ToDoListId=@ToDoListId";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListId", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
