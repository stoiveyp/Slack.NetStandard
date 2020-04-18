using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    internal class CreateConversationRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_private",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }

        [JsonProperty("user_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] UserIds { get; set; }
    }
}