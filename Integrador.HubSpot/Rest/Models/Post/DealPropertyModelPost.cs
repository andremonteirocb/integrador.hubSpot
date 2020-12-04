using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class DealPropertyModelPost : AbstractModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("fieldType")]
        public string FieldType { get; set; }

        [JsonProperty("formField")]
        public bool FormField { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("readOnlyDefinition")]
        public bool ReadOnlyDefinition { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("mutableDefinitionNotDeletable")]
        public bool MutableDefinitionNotDeletable { get; set; }

        [JsonProperty("calculated")]
        public bool Calculated { get; set; }

        [JsonProperty("externalOptions")]
        public bool ExternalOptions { get; set; }
    }
}
