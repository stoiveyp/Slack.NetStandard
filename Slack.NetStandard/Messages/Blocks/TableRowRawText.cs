using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.Messages.Blocks
{

    public class TableRowRawText : ITableRowItem
    {
        public TableRowRawText(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

        public object GenerateRowItem() => new JObject(
            new JProperty("type", "raw_text"),
            new JProperty("text", Text)
            );
    }
}