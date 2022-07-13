﻿using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Blocks
{
    [JsonConverter(typeof(MessageBlockConverter))]
    public interface IMessageBlock
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
