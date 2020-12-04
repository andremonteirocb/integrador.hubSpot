using Newtonsoft.Json;

namespace Integrador.HubSpot.Rest.Models
{
    public class PropertyValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
