using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Plan : IMessageBlock
    {
        public const string MessageBlockType = "plan";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public Plan() { }

        public Plan(string title)
        {
            Title = title;
        }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tasks", NullValueHandling = NullValueHandling.Ignore)]
        public IList<TaskCard> Tasks { get; set; } = new List<TaskCard>();

        public bool ShouldSerializeTasks() => Tasks?.Any() ?? false;
    }
}
