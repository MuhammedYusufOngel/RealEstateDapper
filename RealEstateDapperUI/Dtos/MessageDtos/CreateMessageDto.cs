namespace RealEstateDapperUI.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
    }
}
