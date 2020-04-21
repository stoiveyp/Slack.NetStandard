using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Admin
{
    public class TeamCreateRequest
    {
        [JsonProperty("team_domain")]
        public string TeamDomain { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("team_description", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamDescription { get; set; }

        [JsonProperty("team_discoverability", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TeamDiscoverability TeamDiscoverability { get; set; }
    }
}
