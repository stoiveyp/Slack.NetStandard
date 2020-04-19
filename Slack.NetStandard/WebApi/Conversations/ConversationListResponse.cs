using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationListResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
        public Channel[] Channels { get; set; }
    }
}