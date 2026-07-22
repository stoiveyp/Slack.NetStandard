namespace Slack.NetStandard.Messages.Blocks
{
    public class RichTextCell : ITableRowCell
    {
        public RichTextCell(Messages.Blocks.RichText richText)
        {
            RichText = richText;
        }
        public RichText RichText { get; set; }
        public object GenerateCell() => RichText;
    }
}