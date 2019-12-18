using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.Chat
{
    public class PostMessageResponse:WebApiResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        [JsonProperty("message")]
        public ResponseMessage Message { get; set; }
        
    }
}