using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelRename:CallbackEvent
    {
        public const string EventType = "channel_rename";

        [JsonProperty("channel")]
        public ChannelRenameDetail Channel { get; set; }
    }
}
