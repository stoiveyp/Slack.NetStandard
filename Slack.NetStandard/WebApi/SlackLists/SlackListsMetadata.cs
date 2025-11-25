using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsMetadata
    {
        [JsonProperty("schema")]
        [AcceptedArray]
        public SlackListsSchemaResponse[] Schema { get; set; }

        [JsonProperty("subtask_schema")]
        [AcceptedArray]
        public SlackListsSchemaResponse[] SubtaskSchema { get; set; }
    }
}
