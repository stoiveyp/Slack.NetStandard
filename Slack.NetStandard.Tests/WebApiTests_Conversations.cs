using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Conversations;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Conversations
    {
        [Fact]
        public async Task Conversations_Archive()
        {
            var response = await Utility.AssertWebApi(c => c.Conversations.Archive("ABCDEF"), "conversations.archive",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal("ABCDEF", jobject.Value<string>("channel"));
                }, new WebApiResponse { OK = true });
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Conversations_Close()
        {
            var response = await Utility.AssertWebApi(c => c.Conversations.Close("ABCDEF"), "conversations.close",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal("ABCDEF", jobject.Value<string>("channel"));
                }, new CloseConversationResponse { OK = true, Noop = true, AlreadyClosed = true });
            Assert.True(response.OK);
            Assert.True(response.AlreadyClosed);
            Assert.True(response.Noop);
        }

        [Fact]
        public async Task Conversations_Create()
        {
            var response = await Utility.AssertWebApi(c => c.Conversations.Create("test this", true),
                "conversations.create", "Web_ConversationsCreate.json", j =>
                {
                    Assert.Equal("test this", j.Value<string>("name"));
                    Assert.True(j.Value<bool>("is_private"));
                });
        }

        [Fact]
        public async Task Conversations_History()
        {
            var request = new ConversationHistoryRequest
            {
                Channel= "C1234567890",
                Latest = "1234567890.123456"
            };
            await Utility.AssertWebApi(c => c.Conversations.History(request),
                "conversations.history", "Web_ConversationsHistory.json", j =>
                {
                    Assert.Equal("C1234567890", j.Value<string>("channel"));
                    Assert.Equal("1234567890.123456",j.Value<string>("latest"));
                });
        }

        [Fact]
        public async Task Conversations_info()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Info("C1234567890",null,true), "conversations.info",
                "Web_ConversationsInfo.json", nvc =>
                {
                    Assert.Equal("C1234567890",nvc["channel"]);
                    Assert.Equal("true",nvc["include_num_members"]);
                });
        }

        [Fact]
        public async Task ConversationsInfo()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Invite("C1234567890", "W123","U456"), "conversations.invite", "Web_ConversationsInfo.json",
                nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("W123,U456", nvc["users"]);
                });
        }

        [Fact]
        public async Task ConversationsJoin()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Join("C1234567890"), "conversations.join", "Web_ConversationsInfo.json",
                nvc =>
                {
                    Assert.Single(nvc);
                    Assert.Equal("C1234567890", nvc["channel"]);
                });
        }

        [Fact]
        public async Task ConversationsKick()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Kick("C1234567890","U123"), "conversations.kick", 
                nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("U123", nvc["user"]);
                });
        }

        [Fact]
        public async Task ConversationsLeave()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Leave("C1234567890"), "conversations.leave", 
                nvc =>
                {
                    Assert.Single(nvc);
                    Assert.Equal("C1234567890", nvc["channel"]);
                });
        }

        [Fact]
        public async Task ConversationsList()
        {
            var request = new ConversationListRequest
            {
                Cursor = "ABCDEF",
                ExcludeArchived=true,
                Types="private_channel",
                Limit=10
            };
            await Utility.AssertWebApi(c => c.Conversations.List(request), "conversations.list",
                "Web_ConversationsList.json",
                j =>
                {
                    Assert.Equal("ABCDEF",j.Value<string>("cursor"));
                    Assert.Equal(10,j.Value<int>("limit"));
                    Assert.True(j.Value<bool>("exclude_archived"));
                    Assert.Equal("private_channel",j.Value<string>("types"));
                });
        }

        [Fact]
        public async Task ConversationsMembers()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Members("ABCDEF","DEFGHI",20), "conversations.members",
                "Web_ConversationsMembers.json",
                nvc =>
                {
                    Assert.Equal("ABCDEF",nvc["channel"]);
                    Assert.Equal("DEFGHI",nvc["cursor"]);
                    Assert.Equal(20.ToString(),nvc["limit"]);
                });
        }

        [Fact]
        public async Task ConversationsOpen()
        {
            var request = new ConversationOpenRequest
            {
                Channel = "ABCDEF",
                ReturnIm = true,
                Users = "W123,C123"
            };
            await Utility.AssertWebApi(c => c.Conversations.Open(request), "conversations.open",
                "Web_ConversationsOpen.json",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("channel"));
                    Assert.True(j.Value<bool>("return_im"));
                    Assert.Equal("W123,C123", j.Value<string>("users"));
                });
        }

        [Fact]
        public async Task ConversationsRename()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Rename("C1234567890","new name"), "conversations.rename", "Web_ConversationsInfo.json",
                nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("new name", nvc["name"]);
                });
        }

        [Fact]
        public async Task ConversationsReplies()
        {
            var request = new ConversationRepliesRequest
            {
                ParentMessageTimestamp = "1234567890.123456",
                Channel = "C1234567890",
                Inclusive = true
            };

            await Utility.AssertEncodedWebApi(c => c.Conversations.Replies(request), "conversations.replies", "Web_ConversationsReplies.json",
                nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("1234567890.123456", nvc["ts"]);
                    Assert.Equal("true", nvc["inclusive"]);
                });
        }

        [Fact]
        public async Task ConversationsSetPurpose()
        {
            await Utility.AssertEncodedWebApi<ConversationSetPurposeResponse>(c => c.Conversations.SetPurpose("C1234567890","new purpose"), "conversations.setPurpose","Web_ConversationsSetPurpose.json",
                nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("new purpose", nvc["purpose"]);
                });
        }


        [Fact]
        public async Task ConversationsSetTopic()
        {
            await Utility.AssertEncodedWebApi<ConversationSetTopicResponse>(c => c.Conversations.SetTopic("C1234567890", "new topic"), "conversations.setTopic", "Web_ConversationsSetTopic.json",
                nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("new topic", nvc["topic"]);
                });
        }

        [Fact]
        public async Task ConversationsUnarchive()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Unarchive("C1234567890"), "conversations.unarchive", 
                nvc =>
                {
                    Assert.Single(nvc);
                    Assert.Equal("C1234567890", nvc["channel"]);
                });
        }

    }
}
