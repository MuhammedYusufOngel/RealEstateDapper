using Dapper;
using RealEstateDapperApi.Dtos.MessageDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateMessage(CreateMessageDto createMessageDto)
        {
            string query = "insert into Messages (SenderId, ReceiverId, Subject, Detail, SendDate, isRead) values (@SenderId, @ReceiverId, @Subject, @Detail, @SendDate, @isRead)";
            var parameters = new DynamicParameters();
            parameters.Add("@SenderId", createMessageDto.SenderId);
            parameters.Add("@ReceiverId", createMessageDto.ReceiverId);
            parameters.Add("@Subject", createMessageDto.Subject);
            parameters.Add("@Detail", createMessageDto.Detail);
            parameters.Add("@SendDate", DateTime.Now.ToString());
            parameters.Add("@isRead", false);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteMessage(int id)
        {
            string query = "Delete from Messages where MessageId=@MessageId";
            var parameters = new DynamicParameters();
            parameters.Add("@MessageId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultMessageByUserIdDto>> GetAllMessagesByUserId(int id)
        {
            string query = "select MessageId, UserName, Subject, Detail, SendDate, isRead, ImageUrl from Messages " +
                "inner join AppUser on AppUser.UserId = Messages.ReceiverId " +
                "inner join Employee on AppUser.EmployeeId = Employee.EmployeeId where SenderId=@SenderId";
            var parameter = new DynamicParameters();
            parameter.Add("@SenderId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultMessageByUserIdDto>(query, parameter);
                return values.ToList();
            }
        }

        public async Task<List<ResultMessageByUserIdDto>> GetAllSentMessagesByUserId(int id)
        {
            string query = "select MessageId, UserName, Subject, Detail, SendDate, isRead, ImageUrl from Messages " +
                "inner join AppUser on AppUser.UserId = Messages.SenderId " +
                "inner join Employee on AppUser.EmployeeId = Employee.EmployeeId where ReceiverId=@ReceiverId";
            var parameter = new DynamicParameters();
            parameter.Add("@ReceiverId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultMessageByUserIdDto>(query, parameter);
                return values.ToList();
            }
        }

        public async Task UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            string query = "Update Messages set ReceiverId=@ReceiverId, Subject=@Subject, Detail=@Detail, isRead=@isRead where MessageId=@MessageId";
            var parameters = new DynamicParameters();
            parameters.Add("@MessageId", updateMessageDto.MessageId);
            parameters.Add("@ReceiverId", updateMessageDto.ReceiverId);
            parameters.Add("@Subject", updateMessageDto.Subject);
            parameters.Add("@Detail", updateMessageDto.Detail);
            parameters.Add("@isRead", updateMessageDto.isRead);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
