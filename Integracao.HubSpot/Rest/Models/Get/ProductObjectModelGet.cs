using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class ProductObjectModelGet : AbstractModel
    {
        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        [JsonProperty("portalId")]
        public long PortalId { get; set; }

        [JsonProperty("objectId")]
        public long ObjectId { get; set; }

        [JsonProperty("properties")]
        public PropertiesProductModelGet Properties { get; set; }
    }
}
