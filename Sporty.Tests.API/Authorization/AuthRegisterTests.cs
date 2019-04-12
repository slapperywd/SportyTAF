using System.Net;
using NUnit.Framework;
using Sporty.API.Clients;
using Sporty.API.Clients.Authorization;
using Sporty.API.Models;
using Sporty.Core.Utils;
using Sporty.Tests.API.Constants;

namespace Sporty.Tests.API.Authorization
{
    public class AuthRegisterTests
    {
        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Register)]
        public void RegisterUser_WithRightCredentialsPassed_ReturnsToken()
        {
            var user = new User
            {
                Login = DataGenerator.GenerateEmail(),
                Password = "123"
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Register(user);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.IsTrue(response.Data.Message.Equals("Registred and generated token"));
            Assert.IsTrue(response.Data.Success);
            Assert.NotNull(response.Data.Token);
            Assert.IsTrue(response.Data.Token.Contains("Bearer"));
        }

        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Register)]
        public void RegisterExistingUser_ReturnsBadRequest()
        {
            var user = new User
            {
                Login = "alex@sporty.app",
                Password = "123"
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Register(user);

            Assert.IsNull(response.Data.Token);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.IsFalse(response.Data.Success);
            Assert.IsTrue(response.Data.Message.Equals("User already exists"));
        }

        // ToDo Update this test when API is fixed
        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Register)]
        public void RegisterUser_WithMissingUserName_ReturnsBadRequest()
        {
            var user = new User
            {
                Login = null,
                Password = "123"
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Register(user);

            Assert.IsNull(response.Data.Token);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.IsFalse(response.Data.Success);
            Assert.IsTrue(response.Data.Message.Equals("Incorrect login or password"));
        }

        //ToDo Update this test when API is fixed
        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Register)]
        public void RegisterUser_WithMissingPassword_ReturnsBadRequest()
        {
            var user = new User
            {
                Login = "alex@sporty.app",
                Password = null
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Register(user);

            Assert.IsNull(response.Data.Token);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.IsFalse(response.Data.Success);
            Assert.IsTrue(response.Data.Message.Equals("Incorrect login or password"));
        }

        //ToDo Update this test when API is fixed
        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Register)]
        public void RegisterUser_WithEmptyFields_ReturnsBadRequest()
        {
            var user = new User
            {
                Login = null,
                Password = null
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Register(user);

            Assert.IsNull(response.Data.Token);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.IsFalse(response.Data.Success);
            Assert.IsTrue(response.Data.Message.Equals("Incorrect login or password"));
        }
    }
}
