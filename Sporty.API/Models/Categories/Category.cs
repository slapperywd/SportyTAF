using Newtonsoft.Json;

namespace Sporty.API.Models.Categories
{
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }
    }
}
