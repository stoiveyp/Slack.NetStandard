using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class GetPermalinkResponse:WebApiResponse
    {
        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("permalink",NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }
    }
}
