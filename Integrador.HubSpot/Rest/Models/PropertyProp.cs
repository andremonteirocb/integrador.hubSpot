using Newtonsoft.Json;

namespace Integrador.HubSpot.Rest.Models
{
    public class PropertyProp
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
