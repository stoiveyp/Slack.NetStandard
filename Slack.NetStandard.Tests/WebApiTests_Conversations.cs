using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Canvases;
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
            var response = await Utility.AssertWebApi(c => c.Conversations.Create("test this", true, "T12345"),
                "conversations.create", "Web_ConversationsCreate.json", j =>
                {
                    Assert.Equal("test this", j.Value<string>("name"));
                    Assert.True(j.Value<bool>("is_private"));
                    Assert.Equal("T12345", j.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Conversations_Create_With_Users()
        {
            var response = await Utility.AssertWebApi(
                c => c.Conversations.Create("test this", new[] { "U1", "U2" }, true, "T12345"), "conversations.create",
                "Web_ConversationsCreate.json", j =>
                {
                    var users = j.Value<JArray>("user_ids").Select(t => t.Value<string>()).ToList();
                    
                    Assert.Equal("test this", j.Value<string>("name"));
                    Assert.True(new[] { "U1", "U2" }.SequenceEqual(users));
                    Assert.True(j.Value<bool>("is_private"));
                    Assert.Equal("T12345", j.Value<string>("team_id"));
                });
        }


        [Fact]
        public async Task Conversations_History()
        {
            var request = new ConversationHistoryRequest
            {
                Channel= "C1234567890",
                Latest = "1234567890.123456",
                IncludeAllMetadata = true
            };
            await Utility.AssertEncodedWebApi(c => c.Conversations.History(request),
                "conversations.history", "Web_ConversationsHistory.json", nvc =>
                {
                    Assert.Equal("C1234567890", nvc["channel"]);
                    Assert.Equal("1234567890.123456", nvc["latest"]);
                    Assert.Equal("true", nvc["include_all_metadata"]);
                });
        }

        [Fact]
        public async Task ConversationsInfo()
        {
            await Utility.AssertEncodedWebApi(c => c.Conversations.Info("C1234567890",null,true), "conversations.info",
                "Web_ConversationsInfo.json", nvc =>
                {
                    Assert.Equal("C1234567890",nvc["channel"]);
                    Assert.Equal("true",nvc["include_num_members"]);
                });
        }

        [Fact]
        public async Task ConversationsInvite()
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
                ExcludeArchived = true,
                Types = "private_channel",
                Limit = 10,
                TeamId = "T12345"
            };
            await Utility.AssertEncodedWebApi(c => c.Conversations.List(request), "conversations.list",
                "Web_ConversationsList.json",
                nvc =>
                {
                    Assert.Equal("ABCDEF", nvc["cursor"]);
                    Assert.Equal(10.ToString(), nvc["limit"]);
                    Assert.Equal("true", nvc["exclude_archived"]);
                    Assert.Equal("private_channel", nvc["types"]);
                    Assert.Equal("T12345", nvc["team_id"]);
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
            await Utility.AssertEncodedWebApi(c => c.Conversations.SetTopic("C1234567890", "new topic"), "conversations.setTopic", "Web_ConversationsSetTopic.json",
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

        [Fact]
        public async Task ConversationsInviteShared()
        {
            await Utility.AssertWebApi(c => c.Conversations.InviteShared(new InviteSharedRequest
                {
                Channel = "ABC123",
                TrackingId = "123456",
                ExternalLimited = true,
                Message = "Hi There",
                Emails = new []{"test@test.com"}
                }), "conversations.inviteShared", "Web_ConversationsInviteSharedResponse.json",
                job =>
                {
                    Assert.True(Utility.CompareJson(job, "Web_ConversationsInviteSharedRequest.json"));
                });
        }

        [Fact]
        public async Task ConversationsAcceptSharedInvite()
        {
            await Utility.AssertWebApi(c => c.Conversations.AcceptSharedInvite(new AcceptSharedInviteRequest
                {
                    ChannelName = "puppies-r-us",
                    ChannelId = "ABC213",
                    InviteId = "I01354X80CA",
                    IsPrivate = true,
                    TeamId = "T1234",
                    FreeTrialAccepted = true
            }), "conversations.acceptSharedInvite", "Web_ConversationsAcceptSharedInviteResponse.json",
                job =>
                {
                    Assert.True(Utility.CompareJson(job, "Web_ConversationsAcceptSharedInviteRequest.json"));
                });
        }

        [Fact]
        public async Task ConversationsApproveSharedInvite()
        {
            await Utility.AssertWebApi(c => c.Conversations.ApproveSharedInvite("I123","T123"), "conversations.approveSharedInvite",
                job =>
                {
                    Assert.Equal(2,job.Count);
                    Assert.Equal("I123",job.Value<string>("invite_id"));
                    Assert.Equal("T123",job.Value<string>("target_team"));
                });
        }

        [Fact]
        public async Task ConversationsDeclineSharedInvite()
        {
            await Utility.AssertWebApi(c => c.Conversations.DeclineSharedInvite("I123", "T123"), "conversations.declineSharedInvite",
                job =>
                {
                    Assert.Equal(2, job.Count);
                    Assert.Equal("I123", job.Value<string>("invite_id"));
                    Assert.Equal("T123", job.Value<string>("target_team"));
                });
        }

        [Fact]
        public async Task ConversationsDisconnectSharedNoTeams()
        {
            await Utility.AssertWebApi(c => c.Conversations.DisconnectShared("C123"), "conversations.disconnectShared",
                job =>
                {
                    Assert.Single(job);
                    Assert.Equal("C123", job.Value<string>("channel_id"));
                });
        }

        [Fact]
        public async Task ConversationsDisconnectSharedWithTeams()
        {
            await Utility.AssertWebApi(c => c.Conversations.DisconnectShared("C123","T123","T234"), "conversations.disconnectShared",
                job =>
                {
                    Assert.Equal(2,job.Count);
                    Assert.Equal("C123", job.Value<string>("channel_id"));
                    var jarray = job.Value<JArray>("leaving_team_ids");
                    Assert.Equal(2,jarray.Count);
                    Assert.Equal("T123", jarray[0]);
                    Assert.Equal("T234", jarray[1]);
                });
        }

        [Fact]
        public async Task ConversationsListInvites()
        {
            await Utility.AssertWebApi(c => c.Conversations.ListConnectInvites("ABC123", 13), "conversations.listConnectInvites", "Web_ConversationsListConnectInvites.json",
                job =>
                {
                    Assert.Equal(2, job.Count);
                    Assert.Equal("ABC123", job.Value<string>("cursor_id"));
                    Assert.Equal(13, job.Value<int>("count"));
                });
        }

        [Fact]
        public async Task ConversationsListInviteTeams()
        {
            await Utility.AssertWebApi(c => c.Conversations.ListConnectInvitesForTeam("T1234","ABC123", 13), "conversations.listConnectInvites", "Web_ConversationsListConnectInvites.json",
                job =>
                {
                    Assert.Equal(3, job.Count);
                    Assert.Equal("T1234", job.Value<string>("team_id"));
                    Assert.Equal("ABC123", job.Value<string>("cursor_id"));
                    Assert.Equal(13, job.Value<int>("count"));
                });
        }

        public const string MARKDOWN_TEXT = "> channel canvas!";

        [Fact]
        public async Task Conversations_CanvasCreate()
        {
            await Utility.AssertWebApi(
                c => c.Conversations.CreateCanvas("C1232", new MarkdownContent(MARKDOWN_TEXT)),
                "conversations.canvases.create", jo =>
                {
                    Assert.Equal("C1232", jo.Value<string>("channel_id"));
                    var content = jo.Value<JObject>("document_content");
                    Assert.Equal("markdown", content.Value<string>("type"));
                    Assert.Equal(MARKDOWN_TEXT, content.Value<string>("markdown"));
                });
        }

    }
}
