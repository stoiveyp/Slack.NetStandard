using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationRepliesResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public Message[] Messages { get; set; }

        [JsonProperty("has_more", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasMore { get; set; }
    }
}