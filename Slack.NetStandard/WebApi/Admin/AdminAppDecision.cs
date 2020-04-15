using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    internal class AdminAppDecision
    {
        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("request_id",NullValueHandling = NullValueHandling.Ignore)]
        public string RequestId { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }

    internal class AdminInviteRequestDecision
    {
        [JsonProperty("invite_request_id", NullValueHandling = NullValueHandling.Ignore)]
        public string InviteRequestId { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}
