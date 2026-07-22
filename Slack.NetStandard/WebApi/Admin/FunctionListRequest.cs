using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Admin
{
    public class FunctionListRequest
    {
        [JsonProperty("app_ids")] public List<string> AppIds { get; set; } = new();

        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        public bool ShouldSerializeAppIds() => AppIds?.Any() ?? false;
    }
}
