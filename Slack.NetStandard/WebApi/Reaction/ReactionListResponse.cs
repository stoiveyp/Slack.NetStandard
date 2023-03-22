using Newtonsoft.Json;
using Slack.NetStandard.Objects.Reactions;

namespace Slack.NetStandard.WebApi.Reaction
{
    public class ReactionListResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public ReactionItem[] Items { get; set; }
    }
}
