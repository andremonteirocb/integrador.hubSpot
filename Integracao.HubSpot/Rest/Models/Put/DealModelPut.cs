using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class DealModelPut : AbstractModel
    {
        [JsonIgnore]
        public long DealId { get; set; }

        [JsonProperty("properties")]
        public List<PropertyName> Properties { get; set; }
    }
}
