namespace RealEstateDapperApi.Dtos.LoginDtos
{
    public class CreateLoginDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
    }
}
