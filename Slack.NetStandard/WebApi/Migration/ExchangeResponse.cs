using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Migration
{
    public class ExchangeResponse:WebApiResponse
    {
        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Enterprise { get; set; }

        [JsonProperty("user_id_map",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> UserIdMap { get; set; }

        [JsonProperty("invalid_user_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] InvalidUserIds { get; set; }
    }
}
