using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class TeamInfoResponse:WebApiResponse
    {
        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public Team Team { get; set; }
    }
}
