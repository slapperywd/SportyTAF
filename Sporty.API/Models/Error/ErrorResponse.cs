using Newtonsoft.Json;

namespace Sporty.API.Models.Error
{
    public class ErrorResponse
    {
        [JsonProperty("errors")]
        public Errors Errors { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }
    }
}
