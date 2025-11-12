using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class RichTextCell:SlackListsCell
    {
        [JsonProperty("rich_text")]
        public RichText RichText { get; set; }
    }
}
