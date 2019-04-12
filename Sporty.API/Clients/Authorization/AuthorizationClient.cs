using Newtonsoft.Json;
using RestSharp;
using Sporty.API.Models;
using Sporty.API.Models.Authorization;
using Sporty.API.Models.Error;

namespace Sporty.API.Clients.Authorization
{
    public class AuthorizationClient : BaseClient
    {
        public AuthorizationClient()
        {         
        }

        public AuthorizationClient(User user) : base(user)
        {           
        }

        public IRestResponse<T> Login<T>(User user) where T : new() 
        {
            var request = new RestRequest("/api/auth/login", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody($"{JsonConvert.SerializeObject(user)}");

            return this.RestClient.Execute<T>(request);
        }

        public IRestResponse<ErrorResponse> LoginWithEmptyBody()
        {
            var request = new RestRequest("/api/auth/login", Method.POST);

            request.AddHeader("Content-Type", "application/json");

            return this.RestClient.Execute<ErrorResponse>(request);
        }

        public IRestResponse<AuthResponse> Register(User user)
        {
            var request = new RestRequest("/api/auth/register", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody($"{JsonConvert.SerializeObject(user)}");

            return this.RestClient.Execute<AuthResponse>(request);
        }
    }
}
