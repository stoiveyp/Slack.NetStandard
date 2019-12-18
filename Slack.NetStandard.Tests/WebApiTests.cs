using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.WebApi;
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

        [Fact]
        public async Task Chat_DeleteMessage()
        {
            var http = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("https://slack.com/api/chat.delete", req.RequestUri.ToString());
                Assert.Equal("application/json", req.Content.Headers.ContentType.MediaType);
                var jobject = JObject.Parse(await req.Content.ReadAsStringAsync());
                Assert.Equal("C1234567890",jobject.Value<string>("channel"));
                Assert.Equal("1405894322.002768", jobject.Value<string>("ts"));
            }, Utility.ExampleFileContent<DeleteResponse>("DeleteResponse.json")));
            var client = new SlackWebApiClient(http);
            var response = await client.Chat.Delete("C1234567890","1405894322.002768");
            Assert.True(response.OK);
            Assert.Equal("C024BE91L",response.Channel);
            Assert.Equal("1401383885.000061", response.Timestamp);
        }

        [Fact]
        public async Task Chat_DeleteScheduledMessage()
        {
            var http = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("https://slack.com/api/chat.deleteScheduledMessage", req.RequestUri.ToString());
                Assert.Equal("application/json", req.Content.Headers.ContentType.MediaType);
                var jobject = JObject.Parse(await req.Content.ReadAsStringAsync());
                Assert.Equal("C1234567890", jobject.Value<string>("channel"));
                Assert.Equal("Q1234ABCD", jobject.Value<string>("scheduled_message_id"));
                Assert.True(jobject.Value<bool>("as_user"));
            }, new WebApiResponse{OK=true}));
            var client = new SlackWebApiClient(http);
            var response = await client.Chat.DeleteScheduledMessage("C1234567890", "Q1234ABCD",true);
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Chat_GetPermalink()
        {
            var bustersAddress = "https://ghostbusters.slack.com/archives/C1H9RESGA/p135854651500008";
            var http = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("https://slack.com/api/chat.getPermalink", req.RequestUri.ToString());
                Assert.Equal("application/json", req.Content.Headers.ContentType.MediaType);
                var jobject = JObject.Parse(await req.Content.ReadAsStringAsync());
                Assert.Equal("C1234567890", jobject.Value<string>("channel"));
                Assert.Equal("1234567890.123456", jobject.Value<string>("message_ts"));
            }, new GetPermalinkResponse { OK = true, Channel= "C1H9RESGA", Permalink = bustersAddress}));
            var client = new SlackWebApiClient(http);
            var response = await client.Chat.GetPermalink("C1234567890", "1234567890.123456");
            Assert.True(response.OK);
            Assert.Equal("C1H9RESGA",response.Channel);
            Assert.Equal(bustersAddress,response.Permalink);
        }
    }
}
