using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    internal class AdminAppApproveRequest
    {
        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("request_id",NullValueHandling = NullValueHandling.Ignore)]
        public string RequestId { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}
