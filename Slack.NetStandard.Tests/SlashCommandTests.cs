using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Interaction;
using Slack.NetStandard.WebApi;
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
            var command = new Interaction.SlashCommand(payload + "&test=1");
            Assert.True(command.Payload.ContainsKey("test"));
            Assert.Equal("1", command.Payload["test"]);
        }

        [Fact]
        public void CorrectlyWraps()
        {
            var command = new Interaction.SlashCommand(payload + "&ssl_check=1");
            Assert.True(command.IsSslCheck);
            Assert.Equal("U2147483697",command.UserId);
            Assert.Equal("Steve",command.Username);
            Assert.Equal("C2147483705",command.ChannelId);
            Assert.Equal("test",command.ChannelName);
        }

        [Fact]
        public void SlashCommandMessageRendersCorrectly()
        {
            var message = new InteractionMessage(ResponseType.InChannel) {Text = "It's 80 degrees right now."};
            var expected = new JObject(new JProperty("response_type", "in_channel"),
                new JProperty("text", "It's 80 degrees right now."));
            Assert.True(JToken.DeepEquals(expected,JObject.FromObject(message)));
        }

        [Fact]
        public async Task RespondSendCorrectRequest()
        {
            var command = new Interaction.SlashCommand(payload + "&test=1");
            var message = new InteractionMessage(ResponseType.InChannel) { Text = "It's 80 degrees right now." };

            var client = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post,req.Method);
                Assert.Equal(command.ResponseUrl,req.RequestUri.ToString());
                Assert.Equal(JsonConvert.SerializeObject(message),await req.Content.ReadAsStringAsync());
            }, new WebApiResponse { OK = true }));
            
            
            await command.Respond(message, client);
        }
    }
}
