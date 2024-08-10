using System.Text.Json;
using System.Text;
using RealEstateDapperUI.Dtos.EmployeeDtos;

namespace RealEstateDapperUI.Models
{
    public static class JwtDecode
    {
        public static string DecodeJwt(string Jwtheader, string Jwtpayload)
        {
            //var parts = jwtData.Split('.');

            //if (parts.Length != 3)
            //    throw new ArgumentException("Invalid JWT token format");

            string header = Base64UrlDecode(Jwtheader);
            string payload = Base64UrlDecode(Jwtpayload);

            // Optional: Parsing the JSON strings to objects for further use
            var headerJson = JsonSerializer.Deserialize<object>(header);
            var payloadJson = JsonSerializer.Deserialize<object>(payload);

            // Combining Header and Payload in JSON format for viewing
            var json = new
            {
                Header = headerJson,
                Payload = payloadJson
            };

            return JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true });
        }

        private static string Base64UrlDecode(string input)
        {
            string output = input.Replace('-', '+').Replace('_', '/');
            switch (output.Length % 4)
            {
                case 2: output += "=="; break;
                case 3: output += "="; break;
            }
            var converted = Convert.FromBase64String(output);
            return Encoding.UTF8.GetString(converted);
        }
    }
}
