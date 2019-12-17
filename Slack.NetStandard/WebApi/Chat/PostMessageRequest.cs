using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.Chat
{
    public class PostMessageRequest : Message {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("as_user")]
        public bool AsUser { get; set; }
    }
}