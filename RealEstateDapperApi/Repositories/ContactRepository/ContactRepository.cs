using Dapper;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Dtos.ContactDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async void CreateContact(CreateContactDto createContactDto)
        {
            var query = "insert into Contacts (Name, Subject, Email, Message, SendDate) Values (@Name, @Subject, @Email, @Message, @SendDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createContactDto.Name);
            parameters.Add("@Subject", createContactDto.Subject);
            parameters.Add("@Email", createContactDto.Email);
            parameters.Add("@Message", createContactDto.Message);
            parameters.Add("@SendDate", DateTime.Now.ToString());
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteReaderAsync(query, parameters);
            }
        }

        public async void DeleteContact(int id)
        {
            string query = "Delete from Contact where ContactId=@ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            var query = "Select *from Contacts";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdContactDto> GetContact(int id)
        {
            string query = "Select *from Contacts where ContactId=@ContactId";
            var parameter = new DynamicParameters();
            parameter.Add("@ContactId", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parameter);
                return values;
            }
        }

        public async Task<List<ResultContactDto>> GetLast4ContactsAsync()
        {
            var query = "Select Top(4) *from Contacts order by ContactId desc";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateContact(UpdateContactDto updateContactDto)
        {
            string query = "Update Contacts set Name=@Name, Subject=@Subject, Email=@Email, Message=@Message, SendDate=@SendDate where ContactId=@ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", updateContactDto.ContactId);
            parameters.Add("@Name", updateContactDto.Name);
            parameters.Add("@Subject", updateContactDto.Subject);
            parameters.Add("@Email", updateContactDto.Email);
            parameters.Add("@Message", updateContactDto.Message);
            parameters.Add("@SendDate", updateContactDto.SendDate);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
