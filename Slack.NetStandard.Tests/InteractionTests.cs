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
            var payload = Utility.ExampleFileContent<InteractionPayload>("ViewSubmissionPayload.json");
            var ViewPayload = Assert.IsType<ViewSubmissionPayload>(payload);
            Utility.CompareJson(ViewPayload, "ViewPayload.json");
        }

        [Fact]
        public void BlockActionsPayload()
        {
            var payload = Utility.ExampleFileContent<InteractionPayload>("BlockActionsPayload.json");
            var ViewPayload = Assert.IsType<BlockActionsPayload>(payload);
            Utility.CompareJson(ViewPayload, "BlockActionsPayload.json");
        }

        [Fact]
        public void GlobalShortcutPayload()
        {
            var payload = Utility.ExampleFileContent<InteractionPayload>("GlobalShortcutPayload.json");
            var ViewPayload = Assert.IsType<GlobalShortcutPayload>(payload);
            Utility.CompareJson(ViewPayload, "GlobalShortcutPayload.json");
        }

        [Fact]
        public void MessageActionPayload()
        {
            var payload = Utility.ExampleFileContent<InteractionPayload>("MessageActionPayload.json");
            var ViewPayload = Assert.IsType<MessageActionPayload>(payload);
            Utility.CompareJson(ViewPayload, "MessageActionPayload.json");
        }
    }
}
