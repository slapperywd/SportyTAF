using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sporty.API.Models.Error
{
    public class Errors
    {
        [JsonProperty("")]
        public List<string> ErrorsList { get; set; }
    }
}
