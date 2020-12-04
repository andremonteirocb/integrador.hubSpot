using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class EngagementModelPost : AbstractModel
    {
        [JsonProperty("engagement")]
        public Engagement Engagement { get; set; }

        [JsonProperty("associations")]
        public EngagementAssociations Associations { get; set; }

        [JsonProperty("metadata")]
        public EngagementMetadata Metadata { get; set; }
    }

    public class Engagement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("portalId")]
        public string PortalId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class EngagementMetadata
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class EngagementAssociations
    {
        [JsonProperty("contactIds")]
        public int[] ContactIds { get; set; }

        [JsonProperty("companyIds")]
        public int[] CompanyIds { get; set; }

        [JsonProperty("dealIds")]
        public int[] DealIds { get; set; }

        [JsonProperty("ownerIds")]
        public int[] OwnerIds { get; set; }

        [JsonProperty("ticketIds")]
        public int[] TicketIds { get; set; }
    }
}
