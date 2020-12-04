using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class FormModelGet : AbstractModel
    {
        [JsonProperty("submittedAt")]
        public long SubmittedAt { get; set; }

        [JsonProperty("fields")]
        public PropertyName Properties { get; set; }

        [JsonProperty("context")]
        public ContextForm Context { get; set; }

        [JsonProperty("skipValidation")]
        public bool SkipValidation { get; set; }
    }
}
