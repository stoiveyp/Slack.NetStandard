using Slack.NetStandard.Interaction;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class InteractionTests
    {
        [Fact]
        public void ViewClosedPayload()
        {
            var payload = Utility.ExampleFileContent<InteractionPayload>("ViewClosedPayload.json");
            Assert.IsType<ViewClosedPayload>(payload);
        }

        [Fact]
        public void ViewSubmissionPayload()
        {
            Utility.AssertSubType<InteractionPayload,ViewSubmissionPayload>("ViewSubmissionPayload.json");
        }

        [Fact]
        public void BlockActionsPayload()
        {
            Utility.AssertSubType<InteractionPayload, BlockActionsPayload>("BlockActionsPayload.json");
        }

        [Fact]
        public void GlobalShortcutPayload()
        {
            Utility.AssertSubType<InteractionPayload, GlobalShortcutPayload>("GlobalShortcutPayload.json");
        }

        [Fact]
        public void MessageActionPayload()
        {
            var output = Utility.AssertSubType<InteractionPayload, MessageActionPayload>("MessageActionPayload.json","token");
            Assert.Single(output.Message.OtherFields);
        }
    }
}
