using System;
using System.Collections.Generic;
using System.Text;
using Slack.NetStandard.Interaction;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class InteractionTests
    {
        [Fact]
        public void MessagePayload()
        {
            var payload = Utility.ExampleFileContent<InteractionPayload>("MessagePayload.json");
            var messagePayload = Assert.IsType<MessagePayload>(payload);
            Utility.CompareJson(messagePayload, "MessagePayload.json");
        }

        [Fact]
        public void ViewPayload()
        {
            var payload = Utility.ExampleFileContent<InteractionPayload>("ViewPayload.json");
            var ViewPayload = Assert.IsType<ViewPayload>(payload);
            Utility.CompareJson(ViewPayload, "ViewPayload.json");
        }
    }
}
