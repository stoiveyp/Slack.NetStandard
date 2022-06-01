using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Chat;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Chat
    {
        [Fact]
        public void ClientSetup()
        {
            var client = new SlackWebApiClient("token");
            Assert.Equal("https://slack.com/api/", client.Client.BaseAddress.ToString());
            Assert.Equal("token", client.Client.DefaultRequestHeaders.Authorization.Parameter);
            Assert.Equal("Bearer", client.Client.DefaultRequestHeaders.Authorization.Scheme);
        }

        [Fact]
        public async Task Chat_PostMessage()
        {
            await Utility.AssertWebApi(c => c.Chat.Post(new PostMessageRequest
            {
                Blocks = new List<IMessageBlock> { new Section { Text = new PlainText("stuff") } }
            }), "chat.postMessage", "Web_ChatPostMessageResponse.json",
                jobject => { Assert.NotNull(jobject.Value<JArray>("blocks")); });
        }

        [Fact]
        public async Task Chat_PostEphemeral()
        {
            await Utility.AssertWebApi(c => c.Chat.PostEphemeral(new PostEphemeralMessageRequest
            {
                Blocks = new List<IMessageBlock> { new Section { Text = new PlainText("stuff") } }
            }), "chat.postEphemeral", "Web_ChatPostEphemeral.json",
                jobject =>
                {
                    Assert.NotNull(jobject.Value<JArray>("blocks"));
                });
        }

        [Fact]
        public async Task Chat_DeleteMessage()
        {
            await Utility.AssertWebApi(c => c.Chat.Delete("C1234567890", "1405894322.002768"),
                "chat.delete", "Web_MessageResponse.json",
                jobject =>
                {
                    Assert.Equal("C1234567890", jobject.Value<string>("channel"));
                    Assert.Equal("1405894322.002768", jobject.Value<string>("ts"));
                });
        }

        [Fact]
        public async Task Chat_DeleteScheduledMessage()
        {
            await Utility.AssertWebApi(
                c => c.Chat.ScheduledMessages.Delete("C1234567890", "Q1234ABCD", true),
                "chat.deleteScheduledMessage",
                jobject =>
                {
                    Assert.Equal("C1234567890", jobject.Value<string>("channel"));
                    Assert.Equal("Q1234ABCD", jobject.Value<string>("scheduled_message_id"));
                    Assert.True(jobject.Value<bool>("as_user"));
                });
        }

        [Fact]
        public async Task Chat_GetPermalink()
        {
            var response = await Utility.AssertEncodedWebApi<GetPermalinkResponse>(
                c => c.Chat.Permalink("C1234567890", "1234567890.123456"),
                "chat.getPermalink", "Web_ChatGetPermalink.json",
                nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("1234567890.123456", nvc["message_ts"]);
                });
        }

        [Fact]
        public async Task Chat_MeMessage()
        {
            var response = await Utility.AssertWebApi(c => c.Chat.MeMessage("C123456", "wibbles"),
                "chat.meMessage",
                jobject =>
                {
                    Assert.Equal("C123456", jobject.Value<string>("channel"));
                    Assert.Equal("wibbles", jobject.Value<string>("text"));
                },
                new MessageResponse { OK = true, Channel = "C123444", Timestamp = "123.456" });
            Assert.True(response.OK);
            Assert.Equal("C123444", response.Channel);
            Assert.Equal("123.456", response.Timestamp);
        }

        [Fact]
        public async Task Chat_PostScheduled()
        {
            var currentEpoch = Epoch.For(DateTime.Now.AddSeconds(60));
            var response = await Utility.AssertWebApi(c => c.Chat.ScheduledMessages.Post(new ScheduledMessageRequest
            {
                Blocks = new List<IMessageBlock> { new Section { Text = new PlainText("stuff") } },
                PostAt = currentEpoch
            }), "chat.scheduleMessage",
                jobject =>
                {
                    Assert.NotNull(jobject.Value<JArray>("blocks"));
                    Assert.Equal(currentEpoch, jobject.Value<long>("post_at"));
                });
        }

        [Fact]
        public async Task Chat_UnfurlUrl()
        {
            var response = await Utility.AssertWebApi(c => c.Chat.Unfurl(new UnfurlRequest
            {
                Channel = "C123456",
                Timestamp = "123.456",
                Unfurls = new Dictionary<string, Attachment> { { "example.com/test", new Attachment{Blocks = new List<IMessageBlock> { new Section(new PlainText("test")) } }} }
            }),
                "chat.unfurl",
                jobject =>
                {
                    Assert.Equal("C123456", jobject.Value<string>("channel"));
                    Assert.Equal("123.456", jobject.Value<string>("ts"));
                    Assert.NotNull(jobject.Value<JObject>("unfurls"));
                },
                new WebApiResponse { OK = true });
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Chat_UpdateMessage()
        {
            var newText = "Updated text you carefully authored";
            var response = await Utility.CheckApi(c => c.Chat.Update(new UpdateMessageRequest
            {
                Channel = "C024BE91L",
                Timestamp = "1401383885.000061",
                Text = newText
            }),
                "chat.update",
                jobject =>
                {
                    Assert.Equal("C024BE91L", jobject.Value<string>("channel"));
                    Assert.Equal("1401383885.000061", jobject.Value<string>("ts"));
                    Assert.Equal(newText, jobject.Value<string>("text"));
                },
                new UpdateMessageResponse { OK = true, Channel = "C024BE91L", Timestamp = "1401383885.000061", Text = newText });
            Assert.True(response.OK);
            Assert.Equal("C024BE91L", response.Channel);
            Assert.Equal("1401383885.000061", response.Timestamp);
            Assert.Equal(newText, response.Text);
        }

        [Fact]
        public async Task Chat_ScheduledMessageList()
        {
            var response = await Utility.CheckApi(c => c.Chat.ScheduledMessages.List(new ScheduledMessageListRequest
            {
                Channel = "C123456",
                Latest = 123456,
            }),
                "chat.scheduledMessages.list",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("C123456", jobject.Value<string>("channel"));
                    Assert.Equal(123456, jobject.Value<long>("latest"));
                },
                new ScheduledMessageListResponse
                {
                    OK = true,
                    ScheduledMessages = new[] {new ScheduledMessageSummary
                    {
                        Channel = "ABCDEF"
                    }},
                    ResponseMetadata = new ResponseMetadataCursor
                    {
                        NextCursor = "DFGDFG"
                    }
                });
            Assert.True(response.OK);
            Assert.Single(response.ScheduledMessages);
            Assert.NotNull(response.ResponseMetadata.NextCursor);
        }
    }
}
