using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class AssociationModelPost : AbstractModel
    {
        [JsonProperty("fromObjectId")]
        public long LineItemId { get; set; }

        [JsonProperty("toObjectId")]
        public long DealId { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("definitionId")]
        public int DefinitionId { get; set; }
    }
}
