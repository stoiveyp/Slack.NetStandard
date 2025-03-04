using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AssistantThreadContext
    {
        [JsonProperty("enterprise_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("channel_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelId { get; set; }
    }
}