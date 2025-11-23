using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.Cells;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class CellTests
    {
        [Fact]
        public void Cell_RichText()
        {
            Utility.AssertSubType<SlackListsCell, RichTextCell>("Cells_RichText.json");
        }

        [Fact]
        public void Cell_User()
        {
            Utility.AssertSubType<SlackListsCell, UserCell>("Cells_User.json");
        }

        [Fact]
        public void Cell_Date()
        {
            Utility.AssertSubType<SlackListsCell, DateCell>("Cells_Date.json");
        }

        [Fact]
        public void Cell_Select()
        {
            Utility.AssertSubType<SlackListsCell, SelectCell>("Cells_Select.json");
        }

        [Fact]
        public void Cell_Checkbox()
        {
            Utility.AssertSubType<SlackListsCell, CheckboxCell>("Cells_Checkbox.json");
        }

        [Fact]
        public void Cell_Number()
        {
            Utility.AssertSubType<SlackListsCell, NumberCell>("Cells_Number.json");
        }

        [Fact]
        public void Cell_Email()
        {
            Utility.AssertSubType<SlackListsCell, EmailCell>("Cells_Email.json");
        }

        [Fact]
        public void Cell_Phone()
        {
            Utility.AssertSubType<SlackListsCell, PhoneCell>("Cells_Phone.json");
        }

        [Fact]
        public void Cell_Attachment()
        {
            Utility.AssertSubType<SlackListsCell, AttachmentCell>("Cells_Attachment.json");
        }

        [Fact]
        public void Cell_Link()
        {
            Utility.AssertSubType<SlackListsCell, LinkCell>("Cells_Link.json");
        }

        [Fact]
        public void Cell_Message()
        {
            Utility.AssertSubType<SlackListsCell, MessageCell>("Cells_Message.json");
        }

        [Fact]
        public void Cell_Rating()
        {
            Utility.AssertSubType<SlackListsCell, RatingCell>("Cells_Rating.json");
        }

        [Fact]
        public void Cell_Timestamp()
        {
            Utility.AssertSubType<SlackListsCell, TimestampCell>("Cells_Timestamp.json");
        }

        [Fact]
        public void Cell_Channel()
        {
            Utility.AssertSubType<SlackListsCell, ChannelCell>("Cells_Channel.json");
        }

        [Fact]
        public void Cell_Reference()
        {
            Utility.AssertSubType<SlackListsCell, ReferenceCell>("Cells_Reference.json");
        }
    }
}
