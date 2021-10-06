using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class BillingInfoResponse:WebApiResponse
    {
        [JsonProperty("plan",NullValueHandling = NullValueHandling.Ignore)]
        public string Plan { get; set; }
    }
}
