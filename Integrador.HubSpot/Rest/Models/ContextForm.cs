using Newtonsoft.Json;

namespace Integrador.HubSpot.Rest.Models
{
    public class ContextForm
    {
        [JsonProperty("hutk")]
        public string CookieHubSpot { get; set; }

        [JsonProperty("pageUri")]
        public string PageUri { get; set; }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("pageName")]
        public string PageName { get; set; }
    }
}
