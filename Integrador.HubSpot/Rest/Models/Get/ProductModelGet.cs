using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class ProductModelGet : AbstractModel
    {
        [JsonProperty("objects")]
        public List<ProductObjectModelGet> Objects { get; set; }
    }
    
    public class PropertiesProductModelGet
    {
        [JsonProperty("price")]
        public PropertyValue Price { get; set; }

        [JsonProperty("name")]
        public PropertyValue Name { get; set; }
    }
}
