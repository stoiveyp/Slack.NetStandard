using System;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Bots
{
    public class InfoResponse:WebApiResponse
    {
        [JsonProperty("bot",NullValueHandling = NullValueHandling.Ignore)]
        public BotInfo Bot { get; set; }
    }
}
