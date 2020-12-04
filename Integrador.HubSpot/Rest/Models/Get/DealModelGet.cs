using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class DealModelGet : AbstractModel
    {
        [JsonProperty("portalId")]
        public long PortalId { get; set; }

        [JsonProperty("dealId")]
        public long DealId { get; set; }

        [JsonProperty("isDeleted")]
        public string IsDeleted { get; set; }

        [JsonProperty("associations")]
        public Associations Associations { get; set; }

        [JsonProperty("properties")]
        public PropertiesDealModelGet Properties { get; set; }
    }

    public class PropertiesDealModelGet
    {
        [JsonProperty("pipeline")]
        public PropertyValue Pipeline { get; set; }

        [JsonProperty("dealname")]
        public PropertyValue Dealname { get; set; }

        [JsonProperty("dealstage")]
        public PropertyValue Dealstage { get; set; }
    }
}
