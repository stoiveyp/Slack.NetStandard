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
            c => c.Admin.Conversations.BulkArchive(new []{"xxx", "yyy"}),
            "admin.conversations.bulkArchive",
            "Web_AdminConversationBulkActionResponse.json",
            jobject =>
            {
                jobject.CompareJArray("channel_ids", "xxx","yyy");
            });

        Assert.Equal("Ab123456",response.BulkActionId);
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
            jobject =>
            {
                jobject.CompareJArray("channel_ids", "xxx", "yyy");
            });

        Assert.Equal("Ab123456", response.BulkActionId);
        var notAdded = Assert.Single(response.NotAdded);
        Assert.Equal("C12346", notAdded.ChannelId);
        Assert.Equal("invalid_channel", notAdded.Error);
    }

    [Fact]
    public async Task Admin_ConversationsBulkMove()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.BulkMove("T123456789",new[] { "xxx", "yyy" }),
            "admin.conversations.bulkMove",
            "Web_AdminConversationBulkActionResponse.json",
            jobject =>
            {
                Assert.Equal("T123456789",jobject.Value<string>("target_team_id"));
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
}