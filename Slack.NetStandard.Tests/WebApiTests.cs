using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.WebApi.Chat;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests
    {
        [Fact]
        public void ClientSetup()
        {
            var client = new SlackWebApiClient("token");
            Assert.Equal("https://slack.com/api/",client.Client.BaseAddress.ToString());
            Assert.Equal("token",client.Client.DefaultRequestHeaders.Authorization.Parameter);
            Assert.Equal("Bearer",client.Client.DefaultRequestHeaders.Authorization.Scheme);
        }

        [Fact]
        public async Task Chat_PostMessage()
        {
            var http = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("https://slack.com/api/chat.postMessage",req.RequestUri.ToString());
                Assert.Equal("application/json",req.Content.Headers.ContentType.MediaType);
                var jobject = JObject.Parse(await req.Content.ReadAsStringAsync());
                Assert.NotNull(jobject.Value<JArray>("blocks"));
            },Utility.ExampleFileContent<PostMessageResponse>("PostMessageResponse.json")));
            var client = new SlackWebApiClient(http);
            var response = await client.Chat.PostMessage(new PostMessageRequest
            {
                Blocks = new List<IMessageBlock>{new Section { Text = new PlainText("stuff")}}
            });
            Assert.True(response.OK);
        }
    }
}
