using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Dnd
{
    public class DndStatus:WebApiResponse
    {
        [JsonProperty("dnd_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DndEnabled { get; set; }

        [JsonProperty("next_dnd_start_ts", NullValueHandling = NullValueHandling.Ignore)]
        public long? NextDndStartTimestamp { get; set; }

        [JsonProperty("next_dnd_end_ts", NullValueHandling = NullValueHandling.Ignore)]
        public long? NextDndEndTimestamp { get; set; }

        [JsonProperty("snooze_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SnoozeEnabled { get; set; }

        [JsonProperty("snooze_endtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? SnoozeEndTime { get; set; }

        [JsonProperty("snooze_remaining",NullValueHandling = NullValueHandling.Ignore)]
        public long? SnoozeRemaining { get; set; }
    }
}
