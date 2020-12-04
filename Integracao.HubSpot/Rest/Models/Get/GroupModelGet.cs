using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest.Models.Get
{
    public class GroupModelGet : AbstractModel
    {
        [JsonProperty("name")]
        public string GroupId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("hubspotDefined")]
        public bool HubspotDefined { get; set; }

        [JsonProperty("properties")]
        public List<PropertiesGroupModelGet> Properties { get; set; }
    }

    public class PropertiesGroupModelGet
    {
        [JsonProperty("name")]
        public string PropertyId { get; set; }

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
    }
}
