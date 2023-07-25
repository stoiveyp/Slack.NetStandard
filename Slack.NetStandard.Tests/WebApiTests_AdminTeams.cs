using Slack.NetStandard.WebApi.Admin;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminTeams
{
    [Fact]
    public async Task Admin_TeamsListAdmins()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.ListAdmins("ABCDEF", "DEFGHI", 20),
            "admin.teams.admins.list", "Web_AdminTeamsAdminList.json",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
                Assert.Equal("DEFGHI", nvc["cursor"]);
                Assert.Equal("20", nvc["limit"]);
            });
    }

    [Fact]
    public async Task Admin_TeamsCreateRequest()
    {
        await Utility.AssertWebApi(c => c.Admin.Teams.Create(new TeamCreateRequest
        {
            TeamDomain = "test.com",
            TeamName = "wibble",
            TeamDescription = "this is the thing"
        }),
            "admin.teams.create", "Web_AdminTeamsCreate.json",
            j =>
            {
                Assert.Equal("test.com", j.Value<string>("team_domain"));
                Assert.Equal("wibble", j.Value<string>("team_name"));
                Assert.Equal("this is the thing", j.Value<string>("team_description"));
            });
    }

    [Fact]
    public async Task Admin_TeamsList()
    {
        await Utility.AssertWebApi(c => c.Admin.Teams.List("DEFGHI", 20),
            "admin.teams.list", "Web_AdminTeamsList.json",
            j =>
            {
                Assert.Equal("DEFGHI", j.Value<string>("cursor"));
                Assert.Equal(20, j.Value<int>("limit"));
            });
    }

    [Fact]
    public async Task Admin_TeamsListOwners()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.ListOwners("ABCDEF", "DEFGHI", 20),
            "admin.teams.owners.list", "Web_AdminTeamsOwnersList.json",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
                Assert.Equal("DEFGHI", nvc["cursor"]);
                Assert.Equal("20", nvc["limit"]);
            });
    }

    [Fact]
    public async Task Admin_TeamsSettingsInfo()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.Settings.Info("ABCDEF"),
            "admin.teams.settings.info", "Web_AdminTeamsSettingsInfo.json",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
            });
    }

    [Fact]
    public async Task Admin_TeamsSettingsSetDefaultChannels()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.Settings.SetDefaultChannels("ABCDEF", "AB", "CD", "EF"),
            "admin.teams.settings.setDefaultChannels",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
                Assert.Equal("AB,CD,EF", nvc["channel_ids"]);
            });
    }

    [Fact]
    public async Task Admin_TeamsSettingsSetDescription()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.Settings.SetDescription("ABCDEF", "this is the description"),
            "admin.teams.settings.setDescription",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
                Assert.Equal("this is the description", nvc["description"]);
            });
    }

    [Fact]
    public async Task Admin_TeamsSettingsSetDiscoverability()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.Settings.SetDiscoverability("ABCDEF", TeamDiscoverability.InviteOnly),
            "admin.teams.settings.setDiscoverability",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
                Assert.Equal("invite_only", nvc["discoverability"]);
            });
    }

    [Fact]
    public async Task Admin_TeamsSettingsSetIcon()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.Settings.SetIcon("ABCDEF", "realIconGoesHere"),
            "admin.teams.settings.setIcon",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
                Assert.Equal("realIconGoesHere", nvc["icon_url"]);
            });
    }

    [Fact]
    public async Task Admin_TeamsSettingsSetName()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Teams.Settings.SetName("ABCDEF", "realName"),
            "admin.teams.settings.setName",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["team_id"]);
                Assert.Equal("realName", nvc["name"]);
            });
    }
}