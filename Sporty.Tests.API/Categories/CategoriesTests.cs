using System.Linq;
using System.Net;
using NUnit.Framework;
using Sporty.API.Clients;
using Sporty.API.Clients.Categories;
using Sporty.Tests.API.Constants;

namespace Sporty.Tests.API.Categories
{
   public class CategoriesTests
    {
        [Test]
        [Category(TestCategory.Categories)]
        [Category(Endpoints.Categories.GetCategories)]
        public void GetAllCategories()
        {
            var authClient = ApiClientFactory.GetClient<CategoriesClient>();
            var response = authClient.GetCategories();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(response.Data.Categories.Count > 0);
            Assert.IsTrue(response.Data.Categories.Any(c => c.Name.Equals("Football")));
        }
    }
}
