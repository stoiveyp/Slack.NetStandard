using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class BillableInfoResponse : WebApiResponse
    {
        [JsonProperty("billable_info",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,BillableInfo> BillableInfo { get; set; }
    }
}