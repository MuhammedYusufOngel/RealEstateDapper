using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ContactDtos;
using RealEstateDapperApi.Repositories.ContactRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var values = await _contactRepository.GetAllContacts();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactRepository.CreateContact(createContactDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactRepository.UpdateContact(updateContactDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdContact(int id)
        {
            var value = await _contactRepository.GetContact(id);
            return Ok(value);
        }

        [HttpGet("GetLast4Contacts")]
        public async Task<IActionResult> GetLast4Contacts()
        {
            var value = await _contactRepository.GetLast4Contacts();
            return Ok(value);
        }
    }
}
