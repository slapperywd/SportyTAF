using System.Net;
using NUnit.Framework;
using Sporty.API.Clients;
using Sporty.API.Clients.Authorization;
using Sporty.API.Models;
using Sporty.API.Models.Authorization;
using Sporty.Tests.API.Constants;

namespace Sporty.Tests.API.Authorization
{
    public class AuthLoginTests
    {
        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Login)]
        public void Login_WithRightCredentials_ReturnsUserToken()
        {
            var user = new User
            {
                Login = "alex@sporty.app",
                Password = "123"
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Login<AuthResponse>(user);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(response.Data.Message.Equals("New token has been generated"));
            Assert.IsTrue(response.Data.Success);
            Assert.NotNull(response.Data.Token);
            Assert.IsTrue(response.Data.Token.Contains("Bearer"));
        }

        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Login)]
        [TestCase("test test@mail.com", "111111")]
        [TestCase("blablablabablblabab", "1231213")]
        [TestCase("$$$", "###$")]
        [TestCase("test test@mail.com", "")]
        [TestCase("", "123")]
        [TestCase("duck", "123")]
        [TestCase("", "")]
        public void Login_WithWrongCredentials_ReturnsBadRequest(string email, string password)
        {
            var user = new User
            {
                Login = email,
                Password = password
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Login<AuthResponse>(user);

            Assert.IsNull(response.Data.Token);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.IsFalse(response.Data.Success);
            Assert.IsTrue(response.Data.Message.Equals("Incorrect login or password"));
        }

        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Login)]
        [TestCase("", "test@mail.com")]
        [TestCase("", "123")]
        [TestCase("", "##")]
        public void Login_WithEmptyLogin(string email, string password)
        {
            var user = new User
            {
                Login = email,
                Password = password
            };

            var authClient = ApiClientFactory.GetClient<AuthorizationClient>(user);
            var response = authClient.Login<AuthResponse>(user);

            Assert.IsNull(response.Data.Token);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.IsFalse(response.Data.Success);
            Assert.IsTrue(response.Data.Message.Equals("Incorrect login or password"));
        }

        [Test]
        [Category(TestCategory.Authorization)]
        [Category(Endpoints.Auth.Login)]
        public void Login_WithEmptyBody_ReturnsBadRequest()
        {
            var authClient = ApiClientFactory.GetClient<AuthorizationClient>();
            var response = authClient.LoginWithEmptyBody();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.AreEqual(response.Data.Title, "One or more validation errors occurred.");
            Assert.IsTrue(response.Data.Errors.ErrorsList.Contains("A non-empty request body is required."));
        }
    }
}
