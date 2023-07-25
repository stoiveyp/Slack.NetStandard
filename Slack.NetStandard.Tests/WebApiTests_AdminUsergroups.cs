using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminUsergroups
{
    [Fact]
    public async Task Admin_UsergroupsAddChannels()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Usergroups.AddChannels(new []{"C00000000","C00000001"}, "S00000000","T1234"),
            "admin.usergroups.addChannels", "Web_AdminUsergroupModifyResponse.json",
            j =>
            {
                j.CompareJArray("channel_ids", "C00000000", "C00000001");
                Assert.Equal("S00000000", j.Value<string>("usergroup_id"));
                Assert.Equal("T1234", j.Value<string>("team_id"));
            });
        Assert.Equal(2,response.InvalidChannels.Length);
        Assert.Equal("C1234D1R5", response.InvalidChannels[1]);
    }

    [Fact]
    public async Task Admin_UsergroupsAddTeams()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Usergroups.AddTeams(new[] { "C00000000", "C00000001" }, "S00000000", true),
            "admin.usergroups.addTeams",
            j =>
            {
                j.CompareJArray("team_ids", "C00000000", "C00000001");
                Assert.Equal("S00000000", j.Value<string>("usergroup_id"));
                Assert.True(j.Value<bool>("auto_provision"));
            });
    }

    [Fact]
    public async Task Admin_UsergroupsRemoveChannels()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Usergroups.RemoveChannels(new[] { "C00000000", "C00000001" }, "S00000000"),
            "admin.usergroups.removeChannels", "Web_AdminUsergroupModifyResponse.json",
            j =>
            {
                j.CompareJArray("channel_ids", "C00000000", "C00000001");
                Assert.Equal("S00000000", j.Value<string>("usergroup_id"));
            });
        Assert.Equal(2, response.InvalidChannels.Length);
        Assert.Equal("C1234D1R5", response.InvalidChannels[1]);
    }

    [Fact]
    public async Task Admin_UsergroupsListChannels()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Usergroups.ListChannels( "S00000000",true,"T1234"),
            "admin.usergroups.listChannels", "Web_AdminUsergroupListResponse.json",
            j =>
            {
                Assert.Equal("S00000000", j.Value<string>("usergroup_id"));
                Assert.True(j.Value<bool>("include_num_members"));
                Assert.Equal("T1234", j.Value<string>("team_id"));
            });
        Assert.Equal(4, response.Channels.Length);
        var channel = response.Channels[2];
        Assert.Equal("C024BE91M", channel.Id);
        Assert.Equal("public-channel", channel.Name);
        Assert.Equal("T024BE911", channel.TeamId);
        Assert.Equal(34, channel.NumMembers);
        Assert.True(channel.IsRedacted);
    }
}