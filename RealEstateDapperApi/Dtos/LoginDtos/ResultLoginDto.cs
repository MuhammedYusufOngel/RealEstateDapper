using Newtonsoft.Json.Linq;

namespace RealEstateDapperApi.Dtos.LoginDtos
{
    public class ResultLoginDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
