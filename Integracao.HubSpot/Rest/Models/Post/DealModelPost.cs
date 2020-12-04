using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class DealModelPost : AbstractModel
    {
        [JsonProperty("associations")]
        public Associations Associations { get; set; }

        [JsonProperty("properties")]
        public List<PropertyName> Properties { get; set; }
    }
}
