using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelUnshared:CallbackEvent
    {
        public const string EventType = "channel_unshared";

        [JsonProperty("previously_connected_team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string PreviouslyConnectedTeamId { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("is_ext_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool IsExternallyShared { get; set; }
    }
}
