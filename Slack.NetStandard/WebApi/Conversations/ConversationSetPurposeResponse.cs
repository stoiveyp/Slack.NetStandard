using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationSetPurposeResponse : WebApiResponse
    {
        [JsonProperty("purpose",NullValueHandling = NullValueHandling.Ignore)]
        public string Purpose { get; set; }
    }
}