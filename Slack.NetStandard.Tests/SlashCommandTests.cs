using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class SlashCommandTests
    {
        private const string payload = @"token=gIkuvaNzQIHg97ATvDxqgjtO
&team_id=T0001
&team_domain=example
&enterprise_id=E0001
&enterprise_name=Globular%20Construct%20Inc
&channel_id=C2147483705
&channel_name=test
&user_id=U2147483697
&user_name=Steve
&command=/weather
&text=94070
&response_url=https://hooks.slack.com/commands/1234/5678
&trigger_id=13345224609.738474920.8088930838d88f008e0";

        [Fact]
        public void SlashCommandParsesCorrectly()
        {
            var command = new SlashCommand(payload + "&test=1");
            Assert.True(command.Payload.ContainsKey("test"));
            Assert.Equal("1", command.Payload["test"]);
        }
    }
}
