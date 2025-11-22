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
            Utility.AssertSubType<SlackListsCellDefinition, RichTextCellDefinition>("CellDefinitions_RichText.json");
        }

        [Fact]
        public void CellDefinition_User()
        {
            Utility.AssertSubType<SlackListsCellDefinition, UserCellDefinition>("CellDefinitions_User.json");
        }

        [Fact]
        public void CellDefinition_Date()
        {
            Utility.AssertSubType<SlackListsCellDefinition, DateCellDefinition>("CellDefinitions_Date.json");
        }

        [Fact]
        public void CellDefinition_Select()
        {
            Utility.AssertSubType<SlackListsCellDefinition, SelectCellDefinition>("CellDefinitions_Select.json");
        }

        [Fact]
        public void CellDefinition_Checkbox()
        {
            Utility.AssertSubType<SlackListsCellDefinition, SelectCellDefinition>("CellDefinitions_Checkbox.json");
        }

        [Fact]
        public void CellDefinition_Number()
        {
            Utility.AssertSubType<SlackListsCellDefinition, NumberCellDefinition>("CellDefinitions_Number.json");
        }

        [Fact]
        public void CellDefinition_Email()
        {
            Utility.AssertSubType<SlackListsCellDefinition, EmailCellDefinition>("CellDefinitions_Email.json");
        }

        [Fact]
        public void CellDefinition_Phone()
        {
            Utility.AssertSubType<SlackListsCellDefinition, PhoneCellDefinition>("CellDefinitions_Phone.json");
        }

        [Fact]
        public void CellDefinition_Attachment()
        {
            Utility.AssertSubType<SlackListsCellDefinition, AttachmentCellDefinition>("CellDefinitions_Attachment.json");
        }

        [Fact]
        public void CellDefinition_Link()
        {
            Utility.AssertSubType<SlackListsCellDefinition, LinkCellDefinition>("CellDefinitions_Link.json");
        }

        [Fact]
        public void CellDefinition_Message()
        {
            Utility.AssertSubType<SlackListsCellDefinition, MessageCellDefinition>("CellDefinitions_Message.json");
        }

        [Fact]
        public void CellDefinition_Rating()
        {
            Utility.AssertSubType<SlackListsCellDefinition, RatingCellDefinition>("CellDefinitions_Rating.json");
        }

        [Fact]
        public void CellDefinition_Timestamp()
        {
            Utility.AssertSubType<SlackListsCellDefinition, TimestampCellDefinition>("CellDefinitions_Timestamp.json");
        }

        [Fact]
        public void CellDefinition_Channel()
        {
            Utility.AssertSubType<SlackListsCellDefinition, ChannelCellDefinition>("CellDefinitions_Channel.json");
        }

        [Fact]
        public void CellDefinition_Reference()
        {
            Utility.AssertSubType<SlackListsCellDefinition, ReferenceCellDefinition>("CellDefinitions_Reference.json");
        }
    }
}
