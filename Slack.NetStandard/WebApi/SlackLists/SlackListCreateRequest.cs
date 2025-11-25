using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Messages.Blocks;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListCreateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonConverter(typeof(RichTextAsArrayConverter))]
        [JsonProperty("description_blocks")]
        public RichText DescriptionBlock { get; set; }

        [JsonProperty("schema")]
        public List<SlackListsSchema> Schema { get; set; } = new();

        public bool ShouldSerializeSchema() => Schema?.Any() ?? false;

        [JsonProperty("copy_from_list_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CopyFromListId { get; set; }

        [JsonProperty("include_copied_list_records", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeCopiedListRecords { get; set; }

        [JsonProperty("todo_mode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TodoMode { get; set; }
    }
}
