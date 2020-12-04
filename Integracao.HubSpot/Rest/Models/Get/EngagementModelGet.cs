using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class EngagementModelGet : AbstractModel
    {
        [JsonProperty("engagement")]
        public Engagement Engagement { get; set; }

        [JsonProperty("associations")]
        public EngagementAssociations Associations { get; set; }

        [JsonProperty("metadata")]
        public EngagementMetadata Metadata { get; set; }
    }
}
