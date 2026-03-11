using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class TaskCard : IMessageBlock
    {
        public const string MessageBlockType = "task_card";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public TaskCard() { }

        public TaskCard(string taskId)
        {
            TaskId = taskId;
        }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TaskCardStatus Status { get; set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public RichText Details { get; set; }

        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public RichText Output { get; set; }

        [JsonProperty("sources", NullValueHandling = NullValueHandling.Ignore)]
        public IList<TaskCardSource> Sources { get; set; } = new List<TaskCardSource>();

        public bool ShouldSerializeSources() => Sources?.Any() ?? false;
    }
}
