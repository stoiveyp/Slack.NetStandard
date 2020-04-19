﻿using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi
{
    public class ResponseMetadata
    {
        [JsonProperty("messages",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Messages { get; set; }

        [JsonProperty("warnings", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Warnings { get; set; }
    }
}