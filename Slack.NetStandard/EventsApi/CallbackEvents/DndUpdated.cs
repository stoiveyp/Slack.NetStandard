using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class DndUpdated:CallbackEvent
    {
        public const string EventType = "dnd_updated";

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("dnd_status",NullValueHandling = NullValueHandling.Ignore)]
        public DndStatus DndStatus { get; set; }
    }
}
