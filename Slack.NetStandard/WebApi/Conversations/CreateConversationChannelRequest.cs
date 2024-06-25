using Newtonsoft.Json;
using Slack.NetStandard.WebApi.Canvases;

namespace Slack.NetStandard.WebApi.Conversations
{
    internal class CreateConversationChannelRequest
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("document_content", NullValueHandling = NullValueHandling.Ignore)]
        public CanvasContent Content { get; set; }
    }
}
