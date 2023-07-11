using System.Collections.Generic;
using Slack.NetStandard.WebApi.Admin;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminConversation
{
    [Fact]
    public async Task Admin_ConversationsArchive()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.Archive("xxx"),
            "admin.conversations.archive", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsBulkArchive()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.BulkArchive(new[] { "xxx", "yyy" }),
            "admin.conversations.bulkArchive",
            "Web_AdminConversationBulkActionResponse.json",
            jobject => { jobject.CompareJArray("channel_ids", "xxx", "yyy"); });

        Assert.Equal("Ab123456", response.BulkActionId);
        var notAdded = Assert.Single(response.NotAdded);
        Assert.Equal("C12346", notAdded.ChannelId);
        Assert.Equal("invalid_channel", notAdded.Error);
    }

    [Fact]
    public async Task Admin_ConversationsBulkDelete()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.BulkDelete(new[] { "xxx", "yyy" }),
            "admin.conversations.bulkDelete",
            "Web_AdminConversationBulkActionResponse.json",
            jobject => { jobject.CompareJArray("channel_ids", "xxx", "yyy"); });

        Assert.Equal("Ab123456", response.BulkActionId);
        var notAdded = Assert.Single(response.NotAdded);
        Assert.Equal("C12346", notAdded.ChannelId);
        Assert.Equal("invalid_channel", notAdded.Error);
    }

    [Fact]
    public async Task Admin_ConversationsBulkMove()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.BulkMove("T123456789", new[] { "xxx", "yyy" }),
            "admin.conversations.bulkMove",
            "Web_AdminConversationBulkActionResponse.json",
            jobject =>
            {
                Assert.Equal("T123456789", jobject.Value<string>("target_team_id"));
                jobject.CompareJArray("channel_ids", "xxx", "yyy");
            });

        Assert.Equal("Ab123456", response.BulkActionId);
        var notAdded = Assert.Single(response.NotAdded);
        Assert.Equal("C12346", notAdded.ChannelId);
        Assert.Equal("invalid_channel", notAdded.Error);
    }

    [Fact]
    public async Task Admin_ConversationsSetTeams()
    {
        await Utility.AssertWebApi(
            c => c.Admin.Conversations.SetTeams(new SetTeamsRequest
            {
                Channel = "ABCDEF",
                OrgChannel = true
            }),
            "admin.conversations.setTeams",
            jobject =>
            {
                Assert.Equal(2, jobject.Children().Count());
                Assert.True(jobject.Value<bool>("org_channel"));
                Assert.Equal("ABCDEF", jobject.Value<string>("channel_id"));
            });
    }

    [Fact]
    public async Task Admin_ConversationsConvertToPrivate()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.ConvertToPrivate("xxx"),
            "admin.conversations.convertToPrivate", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsConvertToPublic()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.ConvertToPublic("xxx"),
            "admin.conversations.convertToPublic", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsCreate()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.Create(new CreateConversationRequest
            {
                IsPrivate = true,
                Name = "mychannel",
                Description = "description",
                OrgWide = true,
                TeamId = "T12345"
            }),
            "admin.conversations.create",
            jobject =>
            {
                Assert.True(jobject.Value<bool>("is_private"));
                Assert.True(jobject.Value<bool>("org_wide"));
                Assert.Equal("description", jobject.Value<string>("description"));
                Assert.Equal("mychannel", jobject.Value<string>("name"));
                Assert.Equal("T12345", jobject.Value<string>("team_id"));
            }, new CreateConversationResponse { ChannelId = "C12345", OK = true });

        Assert.True(response.OK);
        Assert.Equal("C12345", response.ChannelId);
    }

    [Fact]
    public async Task Admin_ConversationsDelete()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.Delete("xxx"),
            "admin.conversations.delete", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsDisconnectShared()
    {
        await Utility.AssertWebApi(
        c => c.Admin.Conversations.DisconnectShared("C1235",new[] { "xxx", "yyy" }),
    "admin.conversations.disconnectShared",
        jobject =>
        {
            Assert.Equal("C1235",jobject.Value<string>("channel_id"));
            jobject.CompareJArray("leaving_team_ids", "xxx", "yyy");
        });
    }

    [Fact]
    public async Task Admin_ConversationsPrefs()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.GetConversationPrefs("xxx"), "admin.conversations.getConversationPrefs","channel_id","xxx", new ConversationPrefsResponse{OK = true});
    }

    [Fact]
    public async Task Admin_ConversationsGetCustomRetention()
    {
        var response = await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.GetCustomRetention("xxx"), "admin.conversations.getCustomRetention", "channel_id", "xxx", new CustomRetentionResponse { OK = true,IsPolicyEnabled=true,DurationDays=70 });
        Assert.True(response.IsPolicyEnabled);
        Assert.Equal(70, response.DurationDays);
    }

    [Fact]
    public async Task Admin_ConversationGetTeams()
    {
        var response = await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.GetTeams("xxx", "C1234", 5),
            "admin.conversations.getTeams", "Web_ConversationGetTeams.json", nvc =>
            {
                Assert.Equal("xxx", nvc["channel_id"]);
                Assert.Equal("C1234", nvc["cursor"]);
                Assert.Equal(5.ToString(), nvc["limit"]);
            });

        Assert.Equal(2,response.TeamIds.Length);
        Assert.Equal("T1234", response.TeamIds[0]);
        Assert.Equal("T5679", response.TeamIds[1]);
    }

    [Fact]
    public async Task Admin_ConversationInvite()
    {
        await Utility.AssertWebApi(c => c.Admin.Conversations.Invite("C1234", new[] { "U1234", "U5678" }),"admin.conversations.invite",
            jo =>
            {
                Assert.Equal("C1234", jo.Value<string>("channel_id"));
                jo.CompareJArray("user_ids", "U1234", "U5678");
            });
    }

    [Fact]
    public async Task Admin_ConversationLookup()
    {
        var request = new LookupRequest
        {
            LastMessageActivityBefore = 12345,
            TeamIds = new List<string>(new[]{"T1234","T3456"}),
            Cursor = "C1234",
            Limit=10,
            MaxMemberCount = 20
        };
        var response = await Utility.AssertWebApi(c => c.Admin.Conversations.Lookup(request), "admin.conversations.lookup","Web_ConversationLookup.json",
            jo =>
            {
                Assert.Equal(12345, jo.Value<long>("last_message_activity_before"));
                Assert.Equal("C1234", jo.Value<string>("cursor"));
                Assert.Equal(10, jo.Value<long>("limit"));
                Assert.Equal(20, jo.Value<long>("max_member_count"));
                jo.CompareJArray("team_ids","T1234","T3456");
            });
        Assert.Equal(2,response.Channels.Length);
        Assert.Equal("encoded_id_1", response.Channels[0]);
        Assert.Equal("encoded_id_2", response.Channels[1]);
    }

    [Fact]
    public async Task Admin_ConversationRemoveCustomRetention()
    {
        var response = await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.RemoveCustomRetention("xxx"),
            "admin.conversations.removeCustomRetention", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationRename()
    {
        var response = await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.Rename("C234", "newName"),
            "admin.conversations.rename", nvc =>
            {
                Assert.Equal("C234", nvc["channel_id"]);
                Assert.Equal("newName", nvc["name"]);
            });
    }
}