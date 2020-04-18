using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    public class TestResult:WebApiResponse
    {
        [JsonProperty("args",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,object> Args { get; set; }
    }
}
