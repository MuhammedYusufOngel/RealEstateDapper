namespace RealEstateDapperUI.Dtos.MessageDtos
{
    public class ResultMessageByUserIdDto
    {
        public int MessageId { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool isRead { get; set; }
        public string ImageUrl { get; set; }
    }
}
