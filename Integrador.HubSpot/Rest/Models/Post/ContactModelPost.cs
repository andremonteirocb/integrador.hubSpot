using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class ContactModelPost : AbstractModel
    {
        [JsonIgnore]
        public string Email { get; set; }

        [JsonProperty("properties")]
        public List<PropertyProp> Properties { get; set; }
    }
}
