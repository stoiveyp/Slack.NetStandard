﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class EmojiChanged:CallbackEvent
    {
        public const string EventType = "emoji_changed";

        [JsonProperty("sub_type",NullValueHandling = NullValueHandling.Ignore)]
        public string SubType { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("names",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Names { get; set; }
    }
}
