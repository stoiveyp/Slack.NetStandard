using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class RichTextCellDefinition : SlackListsCellDefinition
    {
        public RichTextCellDefinition(string columnId, string rowId = null) :base(columnId, rowId) { }
        public RichTextCellDefinition(string columnId, RichText richText, string rowId = null) : this(columnId, rowId)
        {
            RichText = richText;
        }

        [JsonProperty("rich_text")]
        [JsonConverter(typeof(RichTextCellConverter))]
        public RichText RichText { get; set; }
    }
}
