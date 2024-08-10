using RealEstateDapperApi.Dtos.ContactDtos;

namespace RealEstateDapperApi.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContacts();
        Task<List<ResultContactDto>> GetLast4Contacts();
        Task CreateContact(CreateContactDto createContactDto);
        Task DeleteContact(int id);
        Task UpdateContact(UpdateContactDto updateContactDto);
        Task<GetByIdContactDto> GetContact(int id);
    }
}
