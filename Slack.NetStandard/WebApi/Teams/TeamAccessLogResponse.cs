using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class TeamAccessLogResponse:WebApiResponse
    {
        [JsonProperty("paging",NullValueHandling = NullValueHandling.Ignore)]
        public Paging Paging { get; set; }

        [JsonProperty("logins",NullValueHandling = NullValueHandling.Ignore)]
        public Login[] Logins { get; set; }
    }
}
