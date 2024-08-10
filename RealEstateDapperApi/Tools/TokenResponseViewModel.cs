namespace RealEstateDapperApi.Tools
{
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel(string token, DateTime expireDate, string userRole)
        {
            Token = token;
            ExpireDate = expireDate;
            UserRole = userRole;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public string UserRole { get; set; }
    }
}
