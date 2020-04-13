using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelRenameDetail : SlackId
    {
        [JsonProperty("created")]
        public long Created { get; set; }
    }
}