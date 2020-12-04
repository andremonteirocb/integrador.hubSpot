using Newtonsoft.Json;

namespace Integrador.HubSpot.Rest.Models
{
    public class PropertyName
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
