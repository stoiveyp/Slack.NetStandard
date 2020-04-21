using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Users
{
    public class PresenceResponse : WebApiResponse
    {
        [JsonProperty("presence",NullValueHandling = NullValueHandling.Ignore)]
        public string Presence { get; set; }
    }
}