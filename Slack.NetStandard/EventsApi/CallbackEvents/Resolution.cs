using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class Resolution
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("scopes",NullValueHandling = NullValueHandling.Ignore)]
        public Scope[] Scopes { get; set; }
    }
}