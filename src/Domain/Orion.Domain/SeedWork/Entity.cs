using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Orion.Domain.SeedWork
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt { get; set; } = SystemClock.Now;
    }
}
