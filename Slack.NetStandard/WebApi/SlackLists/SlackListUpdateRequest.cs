using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListUpdateRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonConverter(typeof(RichTextAsArrayConverter))]
        [JsonProperty("description_blocks", NullValueHandling = NullValueHandling.Ignore)]
        public RichText DescriptionBlock { get; set; }

        [JsonProperty("todo_mode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TodoMode { get; set; }
    }
}
