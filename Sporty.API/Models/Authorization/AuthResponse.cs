using Newtonsoft.Json;

namespace Sporty.API.Models.Authorization
{
    public class AuthResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
