using Slack.NetStandard.Interaction;
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
    }
}
