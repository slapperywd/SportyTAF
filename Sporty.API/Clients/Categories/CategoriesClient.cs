using RestSharp;
using Sporty.API.Models.Categories;

namespace Sporty.API.Clients.Categories
{
    public class CategoriesClient : BaseClient
    {
        public IRestResponse<CategoriesResponse> GetCategories()
        {
            var request = new RestRequest("/api/categories", Method.GET);

            return this.RestClient.Execute<CategoriesResponse>(request);
        }
    }
}
