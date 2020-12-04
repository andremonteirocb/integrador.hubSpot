using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class IntegrationsModelGet : AbstractModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("usageLimit")]
        public int UsageLimit { get; set; }

        [JsonProperty("currentUsage")]
        public int CurrentUsage { get; set; }

        [JsonProperty("fetchStatus")]
        public string FetchStatus { get; set; }
    }
}