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
            var response = await Utility.CheckApi(c => c.Chat.Post(new PostMessageRequest
            {
                Blocks = new List<IMessageBlock> { new Section { Text = new PlainText("stuff") } }
            }), "chat.postMessage", jobject => { Assert.NotNull(jobject.Value<JArray>("blocks")); },
                Utility.ExampleFileContent<PostMessageResponse>("Web_PostMessageResponse.json"));
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Chat_PostEphemeral()
        {
            var response = await Utility.CheckApi(c => c.Chat.PostEphemeral(new PostMessageRequest
            {
                Blocks = new List<IMessageBlock> { new Section { Text = new PlainText("stuff") } }
            }), "chat.postEphemeral",
                jobject => { Assert.NotNull(jobject.Value<JArray>("blocks")); },
                new EphemeralResponse { OK = true, Timestamp = "123.456" });
            Assert.True(response.OK);
            Assert.Equal("123.456", response.Timestamp);
        }

        [Fact]
        public async Task Chat_DeleteMessage()
        {
            var response = await Utility.CheckApi(c => c.Chat.Delete("C1234567890", "1405894322.002768"),
                "chat.delete",
                jobject =>
                {
                    Assert.Equal("C1234567890", jobject.Value<string>("channel"));
                    Assert.Equal("1405894322.002768", jobject.Value<string>("ts"));
                }, Utility.ExampleFileContent<MessageResponse>("MessageResponse.json"));
            Assert.True(response.OK);
            Assert.Equal("C024BE91L", response.Channel);
            Assert.Equal("1401383885.000061", response.Timestamp);
        }

        [Fact]
        public async Task Chat_DeleteScheduledMessage()
        {
            var response = await Utility.CheckApi(
                c => c.Chat.ScheduledMessages.Delete("C1234567890", "Q1234ABCD", true),
                "chat.deleteScheduledMessage",
                jobject =>
                {
                    Assert.Equal("C1234567890", jobject.Value<string>("channel"));
                    Assert.Equal("Q1234ABCD", jobject.Value<string>("scheduled_message_id"));
                    Assert.True(jobject.Value<bool>("as_user"));
                }, new WebApiResponse { OK = true });
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Chat_GetPermalink()
        {
            var bustersAddress = "https://ghostbusters.slack.com/archives/C1H9RESGA/p135854651500008";
            var response = await Utility.CheckApi(
                c => c.Chat.Permalink("C1234567890", "1234567890.123456"),
                "chat.getPermalink",
                jobject =>
                {
                    Assert.Equal("C1234567890", jobject.Value<string>("channel"));
                    Assert.Equal("1234567890.123456", jobject.Value<string>("message_ts"));
                }, new GetPermalinkResponse { OK = true, Channel = "C1H9RESGA", Permalink = bustersAddress });

            Assert.True(response.OK);
            Assert.Equal("C1H9RESGA", response.Channel);
            Assert.Equal(bustersAddress, response.Permalink);
        }

        [Fact]
        public async Task Chat_MeMessage()
        {
            var response = await Utility.CheckApi(c => c.Chat.MeMessage("C123456", "wibbles"),
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
            var response = await Utility.CheckApi(c => c.Chat.ScheduledMessages.Post(new ScheduledMessageRequest
            {
                Blocks = new List<IMessageBlock> { new Section { Text = new PlainText("stuff") } },
                PostAt = currentEpoch
            }), "chat.scheduleMessage",
                jobject =>
                {
                    Assert.NotNull(jobject.Value<JArray>("blocks"));
                    Assert.Equal(currentEpoch, jobject.Value<long>("post_at"));
                },
                new ScheduledMessageResponse { OK = true, PostAt = 1562180400, ScheduledMessageId = "Q1298393284" });
            Assert.True(response.OK);
            Assert.Equal("Q1298393284", response.ScheduledMessageId);
            Assert.Equal(1562180400, response.PostAt);
        }

        [Fact]
        public async Task Chat_UnfurlUrl()
        {
            var response = await Utility.CheckApi(c => c.Chat.Unfurl(new UnfurlRequest
            {
                Channel = "C123456",
                Timestamp = "123.456",
                Unfurls = new Dictionary<string, IMessageBlock[]> { { "example.com/test", new[] { new Section(new PlainText("test")) } } }
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
                "chat.updateMessage",
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
                    ResponseMetadata = new ResponseMetadata
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
