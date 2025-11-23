using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.CellDefinition;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class CellDefinitionTests
    {
        [Fact]
        public void CellDefinition_RichText()
        {
            Utility.AssertSubType<SlackListsCellDefinition, RichTextCellDefinition>("Cells_RichText.json");
        }

        [Fact]
        public void CellDefinition_User()
        {
            Utility.AssertSubType<SlackListsCellDefinition, UserCellDefinition>("Cells_User.json");
        }

        [Fact]
        public void CellDefinition_Date()
        {
            Utility.AssertSubType<SlackListsCellDefinition, DateCellDefinition>("Cells_Date.json");
        }

        [Fact]
        public void CellDefinition_Select()
        {
            Utility.AssertSubType<SlackListsCellDefinition, SelectCellDefinition>("Cells_Select.json");
        }

        [Fact]
        public void CellDefinition_Checkbox()
        {
            Utility.AssertSubType<SlackListsCellDefinition, CheckboxCellDefinition>("Cells_Checkbox.json");
        }

        [Fact]
        public void CellDefinition_Number()
        {
            Utility.AssertSubType<SlackListsCellDefinition, NumberCellDefinition>("Cells_Number.json");
        }

        [Fact]
        public void CellDefinition_Email()
        {
            Utility.AssertSubType<SlackListsCellDefinition, EmailCellDefinition>("Cells_Email.json");
        }

        [Fact]
        public void CellDefinition_Phone()
        {
            Utility.AssertSubType<SlackListsCellDefinition, PhoneCellDefinition>("Cells_Phone.json");
        }

        [Fact]
        public void CellDefinition_Attachment()
        {
            Utility.AssertSubType<SlackListsCellDefinition, AttachmentCellDefinition>("Cells_Attachment.json");
        }

        [Fact]
        public void CellDefinition_Link()
        {
            Utility.AssertSubType<SlackListsCellDefinition, LinkCellDefinition>("Cells_Link.json");
        }

        [Fact]
        public void CellDefinition_Message()
        {
            Utility.AssertSubType<SlackListsCellDefinition, MessageCellDefinition>("Cells_Message.json");
        }

        [Fact]
        public void CellDefinition_Rating()
        {
            Utility.AssertSubType<SlackListsCellDefinition, RatingCellDefinition>("Cells_Rating.json");
        }

        [Fact]
        public void CellDefinition_Timestamp()
        {
            Utility.AssertSubType<SlackListsCellDefinition, TimestampCellDefinition>("Cells_Timestamp.json");
        }

        [Fact]
        public void CellDefinition_Channel()
        {
            Utility.AssertSubType<SlackListsCellDefinition, ChannelCellDefinition>("Cells_Channel.json");
        }

        [Fact]
        public void CellDefinition_Reference()
        {
            Utility.AssertSubType<SlackListsCellDefinition, ReferenceCellDefinition>("Cells_Reference.json");
        }
    }
}
