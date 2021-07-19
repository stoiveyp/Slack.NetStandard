using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Admin
{
    public class TeamInfoResponse:WebApiResponse
    {
        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public Team Team { get; set; }
    }
}
