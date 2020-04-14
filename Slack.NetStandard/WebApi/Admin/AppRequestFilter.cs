using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class AppRequestFilter
    {
        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
    }

    public class AppFilter : AppRequestFilter
    {
        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Enterprise { get; set; }
    }
}
