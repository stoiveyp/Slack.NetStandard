﻿using Newtonsoft.Json;
using Slack.NetStandard.Objects.Reactions;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ReactionRemoved : CallbackEvent
    {
        public const string EventType = "reaction_removed";

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("reaction", NullValueHandling = NullValueHandling.Ignore)]
        public string Reaction { get; set; }

        [JsonProperty("item_user", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemUser { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public ReactionItem Item { get; set; }
    }
}