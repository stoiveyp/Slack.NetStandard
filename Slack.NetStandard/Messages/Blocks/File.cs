﻿using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class File : IMessageBlock
    {
        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("source",NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("external_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; set; }
    }
}