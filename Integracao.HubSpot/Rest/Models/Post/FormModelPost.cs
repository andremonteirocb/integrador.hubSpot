using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class FormModelPost : AbstractModel
    {
    //    [JsonProperty("submittedAt")]
    //    public string SubmittedAt { get; set; }

        [JsonProperty("fields")]
        public List<PropertyName> Properties { get; set; }

        [JsonProperty("context")]
        public ContextForm Context { get; set; }

        [JsonProperty("skipValidation")]
        public bool SkipValidation { get; set; }
    }
}
