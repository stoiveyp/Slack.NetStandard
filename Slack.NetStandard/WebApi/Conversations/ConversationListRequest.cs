﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationListRequest
    {
        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("exclude_archived",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcludeArchived { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("types",NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; set; }
    }
}
