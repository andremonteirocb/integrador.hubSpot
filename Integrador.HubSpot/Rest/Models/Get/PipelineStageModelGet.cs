using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class PipelineStageModelGet : AbstractModel
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("active")]
        public string Active { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("stages")]
        public List<PipelineStagesModelGet> Stages { get; set; }
    }
}
