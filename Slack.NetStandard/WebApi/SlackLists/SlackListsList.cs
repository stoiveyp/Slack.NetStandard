using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsList: File {

        [JsonProperty("list_metadata")]
        public SlackListsMetadata ListMetadata { get; set; }

        [JsonProperty("list_limits", NullValueHandling = NullValueHandling.Ignore)]
        public SlackListsLimits ListLimits { get; set; }
    }
}
