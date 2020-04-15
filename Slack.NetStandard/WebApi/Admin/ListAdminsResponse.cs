using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListAdminsResponse:WebApiResponse
    {
        [JsonProperty("admin_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] AdminIds { get; set; }
    }
}
