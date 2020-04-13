using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class TokenRevokedInformation
    {
        [JsonProperty("oauth",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Oauth { get; set; }

        [JsonProperty("bot",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Bot { get; set; }
    }
}