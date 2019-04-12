using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace Sporty.API
{
    public class SportyDeserializer : IDeserializer
    {
        T IDeserializer.Deserialize<T>(IRestResponse response) => JsonConvert.DeserializeObject<T>(response.Content);
    }
}
