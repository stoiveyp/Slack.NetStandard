using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class Authorization
    {
        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("is_bot",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsBot { get; set; }
    }
}
