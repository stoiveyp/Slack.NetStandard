using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class GroupRename : CallbackEvent
    {
        public const string EventType = "group_rename";

        [JsonProperty("channel")]
        public ChannelRenameDetail Channel { get; set; }
    }
}