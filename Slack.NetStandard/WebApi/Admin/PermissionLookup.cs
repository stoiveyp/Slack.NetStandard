using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    [AcceptedArray]
    public class PermissionLookup
    {
        [JsonProperty("user_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] UserIds { get; set; }

        [JsonProperty("channel_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] ChannelIds { get; set; }

        [JsonProperty("complete",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Complete { get; set; }

        [JsonProperty("who_can_run",NullValueHandling = NullValueHandling.Ignore)]
        public PermissionLookupType WhoCanRun { get; set; }
    }
}
