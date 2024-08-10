using RealEstateDapperApi.Dtos.MessageDtos;

namespace RealEstateDapperApi.Repositories.MessageRepository
{
    public interface IMessageRepository
    {
        Task<List<ResultMessageByUserIdDto>> GetAllMessagesByUserId(int id);
        Task<List<ResultMessageByUserIdDto>> GetAllSentMessagesByUserId(int id);
        Task CreateMessage(CreateMessageDto createMessageDto);
        Task DeleteMessage(int id);
        Task UpdateMessage(UpdateMessageDto updateMessageDto);
    }
}
