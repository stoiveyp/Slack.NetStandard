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
        public void MessagePayload()
        {
            var payload = Utility.ExampleFileContent<InteractionPayload>("InteractiveMessagePayload.json");
            var messagePayload = Assert.IsType<InteractiveMessagePayload>(payload);
            Utility.CompareJson(messagePayload, "InteractiveMessagePayload.json");
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
    }
}
