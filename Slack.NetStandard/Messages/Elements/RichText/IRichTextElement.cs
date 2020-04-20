﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    [JsonConverter(typeof(RichTextElementConverter))]
    public abstract class RichTextElement
    {
        [JsonProperty("type")]
        public string Type { get; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }

    public class UnknownRichTextElement : RichTextElement
    {

    }
}
