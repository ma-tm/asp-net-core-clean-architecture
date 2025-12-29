using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Orion.Domain.StoryDomain.Entities
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Story
    {
        // [JsonProperty("id")]
        public Guid Id { get; set; }

        // [JsonProperty("text")]
        public string Text { get; set; }

        // [JsonProperty("images")]
        public string[] Images { get; set; }
    }
}
