using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class GlobalShortcutPayload: ShortcutPayload
    {
        [JsonProperty("action_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ActionTimestamp { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Channel { get; set; }
    }
}
