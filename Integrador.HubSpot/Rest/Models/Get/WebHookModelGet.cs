using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class WebHookModelGet : AbstractModel
    {
        [JsonProperty("vid")]
        public long ContactID { get; set; }

        [JsonProperty("properties")]
        public PropertiesWebHookModelGet Properties { get; set; }
    }

    public class PropertiesWebHookModelGet
    {
        [JsonProperty("email")]
        public PropertyValue Email { get; set; }

        [JsonProperty("firstname")]
        public PropertyValue Firstname { get; set; }

        [JsonProperty("lastname")]
        public PropertyValue Lastname { get; set; }

        [JsonProperty("phone")]
        public PropertyValue Phone { get; set; }

        [JsonProperty("mobilephone")]
        public PropertyValue MobilePhone { get; set; }

        [JsonProperty("city")]
        public PropertyValue City { get; set; }

        [JsonProperty("state")]
        public PropertyValue State { get; set; }
    }
}
