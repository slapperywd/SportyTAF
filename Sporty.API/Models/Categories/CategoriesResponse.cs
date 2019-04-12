using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sporty.API.Models.Categories
{
    public class CategoriesResponse
    {
        [JsonProperty("data")]
        public List<Category> Categories { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
