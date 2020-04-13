using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelCreationDetail:SlackId
    {
        [JsonProperty("created",NullValueHandling = NullValueHandling.Ignore)]
        public long Created { get; set; }

        [JsonProperty("creator",NullValueHandling = NullValueHandling.Ignore)]
        public string Creator { get; set; }
    }
}