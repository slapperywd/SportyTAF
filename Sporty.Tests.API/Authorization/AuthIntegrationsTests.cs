using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sporty.API.Clients;
using Sporty.API.Clients.Authorization;
using Sporty.API.Models;
using Sporty.API.Models.Authorization;
using Sporty.Core.Utils;
using Sporty.Tests.API.Constants;

namespace Sporty.Tests.API.Authorization
{
    public class AuthIntegrationsTests
    {
        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Register)]
        [Category(Endpoints.Auth.Login)]
        public void RegisterNewUser_LoginWithCreatedUser_ReturnsTokenAndOkStatus()
        {
            var user = new User
            {
                Login = DataGenerator.GenerateEmail(),
                Password = "123"
            };

            Console.WriteLine($"USER:\nlogin: {user.Login}\npass: {user.Password}");

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            authClient.Register(user);
            var response = authClient.Login<AuthResponse>(user);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(response.Data.Message.Equals("New token has been generated"));
            Assert.IsTrue(response.Data.Success);
            Assert.NotNull(response.Data.Token);
            Assert.IsTrue(response.Data.Token.Contains("Bearer"));
        }
    }
}
