using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.MessageDtos;
using RealEstateDapperApi.Repositories.MessageRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("GetAllMessagesByUserId")]
        public async Task<IActionResult> GetAllMessagesByUserId(int id)
        {
            var values = await _messageRepository.GetAllMessagesByUserId(id);
            return Ok(values);
        }

        [HttpGet("GetAllSentMessagesByUserId")]
        public async Task<IActionResult> GetAllSentMessagesByUserId(int id)
        {
            var values = await _messageRepository.GetAllSentMessagesByUserId(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _messageRepository.CreateMessage(createMessageDto);
            return Ok("👍");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageRepository.DeleteMessage(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _messageRepository.UpdateMessage(updateMessageDto);
            return Ok("👍");
        }
    }
}
