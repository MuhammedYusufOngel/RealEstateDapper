using RealEstateDapperApi.Dtos.ContactDtos;

namespace RealEstateDapperApi.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactsAsync();
        Task<List<ResultContactDto>> GetLast4ContactsAsync();
        void CreateContact(CreateContactDto createContactDto);
        void DeleteContact(int id);
        void UpdateContact(UpdateContactDto updateContactDto);
        Task<GetByIdContactDto> GetContact(int id);
    }
}
