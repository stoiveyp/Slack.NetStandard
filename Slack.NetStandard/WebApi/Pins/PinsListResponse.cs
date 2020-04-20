using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Pins
{
    public class PinsListResponse:WebApiResponse
    {
        [JsonProperty("items",NullValueHandling = NullValueHandling.Ignore)]
        public Message[] Items { get; set; }
    }
}
