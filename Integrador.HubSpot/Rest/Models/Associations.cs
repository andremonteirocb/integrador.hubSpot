using Newtonsoft.Json;

namespace Integrador.HubSpot.Rest.Models
{
    public class Associations
    {
        [JsonProperty("associatedVids")]
        public long[] ContactIds { get; set; }
    }
}
