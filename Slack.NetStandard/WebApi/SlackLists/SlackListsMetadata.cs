using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Messages.Blocks;
using System.Collections;
using System.Collections.Generic;

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

        [JsonProperty("views", NullValueHandling = NullValueHandling.Ignore)]
        [AcceptedArray]
        public SlackListsView[] Views { get; set; }

        [JsonConverter(typeof(RichTextAsArrayConverter))]
        [JsonProperty("description_blocks", NullValueHandling = NullValueHandling.Ignore)]
        public RichText DescriptionBlock { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("is_trial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTrial { get; set; }

        [JsonProperty("todo_mode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TodoMode { get; set; }

        [JsonProperty("creation_source", NullValueHandling = NullValueHandling.Ignore)]
        public SlackListsCreationSource CreationSource { get; set; }

        [JsonProperty("default_view", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultView { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; } = new();
    }
}
