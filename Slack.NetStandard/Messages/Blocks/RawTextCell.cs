using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.Messages.Blocks
{

    public class RawTextCell : ITableRowCell
    {
        public RawTextCell(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

        public object GenerateCell() => new JObject(
            new JProperty("type", "raw_text"),
            new JProperty("text", Text)
            );
    }
}