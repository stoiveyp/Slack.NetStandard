namespace Slack.NetStandard.Messages.Blocks
{
    public class TableRowRichText : ITableRowItem
    {
        public TableRowRichText(Messages.Blocks.RichText richText)
        {
            RichText = richText;
        }
        public RichText RichText { get; set; }
        public object GenerateRowItem() => RichText;
    }
}