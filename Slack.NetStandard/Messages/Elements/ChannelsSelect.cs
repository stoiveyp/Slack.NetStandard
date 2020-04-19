﻿using System.Collections.Generic;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class ChannelsSelect:IMessageElement
    {
        public const string ElementType = "channels_select";
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_channel",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialChannel { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }
}