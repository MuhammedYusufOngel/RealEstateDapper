namespace RealEstateDapperUI.Dtos.LoginDtos
{
    public class ResultLoginDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public string UserRole { get; set; }
    }
}
