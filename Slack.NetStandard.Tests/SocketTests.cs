using System.Collections.Generic;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Interaction;
using Slack.NetStandard.Socket;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class SocketTests
    {
        [Fact]
        public void Acknowledge()
        {
            Utility.AssertType<Acknowledge>("Socket_Acknowledge.json");
        }

        [Fact]
        public void Hello()
        {
            Utility.AssertType<Hello>("Socket_Hello.json");
        }

        [Fact]
        public void Disconnect()
        {
            Utility.AssertType<Disconnect>("Socket_Disconnect.json");
        }

        [Fact]
        public void Envelope()
        {
            var dict = Utility.AssertType<Dictionary<string, Envelope>>("Socket_Envelope.json");
            var kvp = Assert.Single(dict);
            Assert.Equal("envelope",kvp.Key);
            Assert.NotNull(kvp.Value);
            Assert.Equal("37053613634.26768298162.440952c06ef4de2653466a48fe495f93", kvp.Value.EnvelopeId);
            Assert.Equal("slash_commands", kvp.Value.Type);
            Assert.IsType<SlashCommand>(kvp.Value.Payload);
            Assert.True(kvp.Value.AcceptsResponsePayload);
            Assert.Single(kvp.Value.Otherfields);
        }

        [Fact]
        public void EnvelopeEvent()
        {
            var evt = Utility.AssertType<Envelope>("Socket_EnvelopeEvent.json");
            Assert.NotNull(evt);
            Assert.Equal("events_api", evt.Type);
            var callback = Assert.IsType<EventCallback>(evt.Payload);
            Assert.IsType<AppHomeOpened>(callback.Event);
        }

        [Fact]
        public void EnvelopeInteraction()
        {
            var evt = Utility.AssertType<Envelope>("Socket_EnvelopeInteraction.json");
            Assert.NotNull(evt);
            Assert.Equal("interactive", evt.Type);
            Assert.IsType<ViewSubmissionPayload>(evt.Payload);
        }
    }
}
