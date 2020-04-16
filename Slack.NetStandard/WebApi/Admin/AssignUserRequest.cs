using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class AssignUserRequest
    {
        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("channel_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelIds { get; set; }

        [JsonProperty("is_restricted",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRestricted { get; set; }

        [JsonProperty("is_ultra_restricted",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUltraRestricted { get; set; }
    }
}
