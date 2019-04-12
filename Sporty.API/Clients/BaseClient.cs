using System;
using Newtonsoft.Json;
using RestSharp;
using Sporty.API.Models;
using Sporty.API.Models.Authorization;

namespace Sporty.API.Clients
{
    public class BaseClient
    {
        protected IRestClient RestClient { get; set; } = new RestClient();
        protected User User { get; set; }

        public BaseClient()
        {
            this.RestClient.AddHandler("application/json", () => new SportyDeserializer());
            this.RestClient.AddHandler("text/json", () => new SportyDeserializer());
            this.RestClient.AddHandler("*+json", () => new SportyDeserializer());
            this.RestClient.BaseUrl = new Uri("https://sportyapp.azurewebsites.net");
        }

        public BaseClient(User user) : this()
        {
            this.User = user;
        }

        protected string GetAuthToken()
        {
            var request = new RestRequest("/api/auth/login", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody($"{JsonConvert.SerializeObject(this.User)}");
            var response = this.RestClient.Execute(request);

            var result = JsonConvert.DeserializeObject<AuthResponse>(response.Content);

            return result.Token;
        }
    }
}
