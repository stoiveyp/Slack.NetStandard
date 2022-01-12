using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class TeamRequestFilter:CursorLimit
    {
        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        [JsonProperty("enterprise_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Enterprise { get; set; }
    }
}
