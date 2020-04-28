using Slack.NetStandard.Interaction;
using Slack.NetStandard.Messages.Elements;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class InteractionTests
    {
        [Fact]
        public void ViewClosedPayload()
        {
            Assert.Null(Utility.AssertSubType<InteractionPayload,ViewClosedPayload>("ViewClosedPayload.json").OtherFields);
        }

        [Fact]
        public void ViewSubmissionPayload()
        {
            Assert.Null(Utility.AssertSubType<InteractionPayload,ViewSubmissionPayload>("ViewSubmissionPayload.json").OtherFields);
        }

        [Fact]
        public void BlockActionsPayload()
        {
            Assert.Null(Utility.AssertSubType<InteractionPayload, BlockActionsPayload>("BlockActionsPayload.json").OtherFields);
        }

        [Fact]
        public void GlobalShortcutPayload()
        {
            Assert.Null(Utility.AssertSubType<InteractionPayload, GlobalShortcutPayload>("GlobalShortcutPayload.json").OtherFields);
        }

        [Fact]
        public void MessageActionPayload()
        {
            Assert.Null(Utility.AssertSubType<InteractionPayload, MessageActionPayload>("MessageActionPayload.json","token").OtherFields);
        }

        [Fact]
        public void MultiStaticSelect()
        {
            Utility.AssertSubType<IMessageElement, MultiStaticSelect>("Interaction_MultiStaticSelect.json", "token");
        }

        [Fact]
        public void MultiExternalSelect()
        {
            Utility.AssertSubType<IMessageElement, MultiExternalSelect>("Interaction_MultiExternalSelect.json", "token");
        }

        [Fact]
        public void MultiUsersSelect()
        {
            Utility.AssertSubType<IMessageElement, MultiUsersSelect>("Interaction_MultiUsersSelect.json", "token");
        }

        [Fact]
        public void MultiConversationsSelect()
        {
            Utility.AssertSubType<IMessageElement, MultiConversationsSelect>("Interaction_MultiConversationsSelect.json", "token");
        }

        [Fact]
        public void MultiChannelsSelect()
        {
            Utility.AssertSubType<IMessageElement, MultiChannelsSelect>("Interaction_MultiChannelsSelect.json", "token");
        }
    }
}
