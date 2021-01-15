using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps
{
    public class OpenConnectionResponse:WebApiResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
