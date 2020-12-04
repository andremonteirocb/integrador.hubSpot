using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class ContactModelGet : AbstractModel
    {
        [JsonProperty("isNew")]
        public bool IsNew { get; set; }

        [JsonProperty("vid")]
        public long ContactId { get; set; }

        [JsonProperty("portal-id")]
        public long Portalid { get; set; }

        [JsonProperty("is-contact")]
        public bool IsContact { get; set; }

        [JsonProperty("properties")]
        public PropertiesContactModelGet Properties { get; set; }
    }

    public class PropertiesContactModelGet
    {
        [JsonProperty("firstname")]
        public PropertyValue Firstname { get; set; }

        [JsonProperty("lastname")]
        public PropertyValue Lastname { get; set; }

        [JsonProperty("city")]
        public PropertyValue City { get; set; }

        [JsonProperty("company")]
        public PropertyValue Company { get; set; }

        [JsonProperty("state")]
        public PropertyValue State { get; set; }

        [JsonProperty("Email")]
        public PropertyValue Email { get; set; }

        [JsonProperty("zip")]
        public PropertyValue Zip { get; set; }

        [JsonProperty("address")]
        public PropertyValue Address { get; set; }

        [JsonProperty("phone")]
        public PropertyValue Phone { get; set; }
    }
}
