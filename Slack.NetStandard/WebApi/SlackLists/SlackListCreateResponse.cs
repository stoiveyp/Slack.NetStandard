using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListCreateResponse : WebApiResponse
    {
        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("list_metadata")]
        public SlackListsMetadata ListMetadata { get; set; }

    }
}
