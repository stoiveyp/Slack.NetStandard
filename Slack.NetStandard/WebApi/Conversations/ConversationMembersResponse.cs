using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationMembersResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Members { get; set; }
    }
}