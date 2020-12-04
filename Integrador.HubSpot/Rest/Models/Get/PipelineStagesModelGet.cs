using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class PipelineStagesModelGet : AbstractModel
    {
        [JsonProperty("stageId")]
        public string StageId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("active")]
        public string Active { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }
    }
}
