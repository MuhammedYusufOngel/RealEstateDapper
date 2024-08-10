namespace RealEstateDapperApi.Dtos.MessageDtos
{
    public class UpdateMessageDto
    {
        public int MessageId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public bool isRead { get; set; }
    }
}
