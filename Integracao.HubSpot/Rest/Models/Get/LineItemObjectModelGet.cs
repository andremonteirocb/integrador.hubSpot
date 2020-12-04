using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class LineItemObjectModelGet : AbstractModel
    {
        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        [JsonProperty("portalId")]
        public long PortalId { get; set; }

        [JsonProperty("objectId")]
        public long ObjectId { get; set; }

        [JsonProperty("properties")]
        public PropertiesLineItemObjectModelGet Properties { get; set; }
    }

    public class PropertiesLineItemObjectModelGet
    {
        [JsonProperty("amount")]
        public PropertyValue Amount { get; set; }

        [JsonProperty("quantity")]
        public PropertyValue Quantity { get; set; }

        [JsonProperty("price")]
        public PropertyValue Price { get; set; }

        [JsonProperty("name")]
        public PropertyValue Name { get; set; }

        [JsonProperty("description")]
        public PropertyValue Description { get; set; }
    }
}
