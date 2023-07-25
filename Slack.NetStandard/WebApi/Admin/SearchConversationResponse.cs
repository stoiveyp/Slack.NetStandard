using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Admin;

public class SearchConversationResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("conversations",NullValueHandling = NullValueHandling.Ignore)]
    public Conversation[] Conversations { get; set; }
}