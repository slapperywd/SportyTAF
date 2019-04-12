using Sporty.API.Clients;
using Sporty.API.Clients.Authorization;
using Sporty.API.Models;
using Sporty.API.Models.Authorization;

namespace Sporty.API.Services.Authorization
{
    public class AuthorizationService
    {
        public void Login(User user)
        {
            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            authClient.Login<AuthResponse>(user);
        }
    }
}
