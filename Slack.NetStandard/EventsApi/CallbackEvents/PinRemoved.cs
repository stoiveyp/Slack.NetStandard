﻿using Newtonsoft.Json;
using Slack.NetStandard.Objects.Pins;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class PinRemoved : CallbackEvent
    {
        public const string EventType = "pin_removed";

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("channel_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public PinnedItem Item { get; set; }

        [JsonProperty("has_pins",NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasPins { get; set; }
    }
}