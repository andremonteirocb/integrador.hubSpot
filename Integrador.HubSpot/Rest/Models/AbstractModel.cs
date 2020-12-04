using Newtonsoft.Json;

namespace Integrador.HubSpot.Rest.Models
{
    public abstract class AbstractModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public virtual string ToJson(bool idented = false)
        {
            var identedMode = idented ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(this, identedMode);
            return jsonData;
        }

        public virtual string Validar(bool lancarException = false)
        {
            if (!string.IsNullOrEmpty(this.Status) && this.Status.Equals("error"))
            {
                if (lancarException)
                    throw new System.Exception(this.Message);

                return this.Message;
            }
            return string.Empty;
        }
    }
}
