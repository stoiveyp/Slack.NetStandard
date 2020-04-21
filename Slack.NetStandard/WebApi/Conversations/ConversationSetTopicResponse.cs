using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationSetTopicResponse : WebApiResponse
    {
        [JsonProperty("topic", NullValueHandling = NullValueHandling.Ignore)]
        public string Topic { get; set; }
    }
}