using System;
using System.Linq;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminUsers
{
    [Fact]
    public async Task Admin_UsersAssign()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.Assign(new AssignUserRequest
        {
            TeamId = "ABCDEF",
            UserId = "DEFGHI",
            ChannelIds = "C123,C3456",
            IsRestricted = true
        }),
            "admin.users.assign",
            j =>
            {
                Assert.Equal(4, j.Children().Count());
                Assert.Equal("ABCDEF", j.Value<string>("team_id"));
                Assert.Equal("DEFGHI", j.Value<string>("user_id"));
                Assert.Equal("C123,C3456", j.Value<string>("channel_ids"));
                Assert.True(j.Value<bool>("is_restricted"));
            });
    }

    [Fact]
    public async Task Admin_UsersInvite()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.Invite(new InviteUserRequest
        {
            TeamId = "ABCDEF",
            Email = "test@TEst.com",
            ChannelIds = "C123,C3456",
            IsRestricted = true
        }),
            "admin.users.invite",
            j =>
            {
                Assert.Equal(4, j.Children().Count());
                Assert.Equal("ABCDEF", j.Value<string>("team_id"));
                Assert.Equal("test@TEst.com", j.Value<string>("email"));
                Assert.Equal("C123,C3456", j.Value<string>("channel_ids"));
                Assert.True(j.Value<bool>("is_restricted"));
            });
    }

    [Fact]
    public async Task Admin_UsersList()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.List("DEFGHI", 20),
            "admin.users.list", "Web_AdminUsersList.json",
            j =>
            {
                Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                Assert.Equal(20, j.Value<int>("limit"));
            });
    }

    [Fact]
    public async Task Admin_UsersRemove()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.Remove("DEFGHI", "ABCDEF"),
            "admin.users.remove",
            j =>
            {
                Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                Assert.Equal("ABCDEF", j.Value<string>("user_id"));
            });
    }

    [Fact]
    public async Task Admin_UsersSetAdmin()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.SetAdmin("DEFGHI", "ABCDEF"),
            "admin.users.setAdmin",
            j =>
            {
                Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                Assert.Equal("ABCDEF", j.Value<string>("user_id"));
            });
    }

    [Fact]
    public async Task Admin_UsersSetOwner()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.SetOwner("DEFGHI", "ABCDEF"),
            "admin.users.setOwner",
            j =>
            {
                Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                Assert.Equal("ABCDEF", j.Value<string>("user_id"));
            });
    }

    [Fact]
    public async Task Admin_UsersSetRegular()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.SetRegular("DEFGHI", "ABCDEF"),
            "admin.users.setRegular",
            j =>
            {
                Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                Assert.Equal("ABCDEF", j.Value<string>("user_id"));
            });
    }

    [Fact]
    public async Task Admin_UsersSetExpiration()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.SetExpiration("DEFGHI", "ABCDEF", 123456),
            "admin.users.setExpiration",
            j =>
            {
                Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                Assert.Equal("ABCDEF", j.Value<string>("user_id"));
                Assert.Equal(123456, j.Value<long>("expiration_ts"));
            });
    }

    [Fact]
    public async Task Admin_UsersSessionReset()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Users.ResetSession("ABCDEF", SessionType.WebOnly),
            "admin.users.session.reset",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["user_id"]);
                Assert.Equal("true", nvc["web_only"]);
            });
    }

    [Fact]
    public async Task Admin_UsersUnsupportedVersionsExport()
    {
        var supportDate = DateTime.UtcNow.AddMonths(-1);
        var sessionDate = DateTime.UtcNow.AddDays(-1);

        await Utility.AssertEncodedWebApi(c => c.Admin.Users.UnsupportedVersions(supportDate, sessionDate),
            "admin.users.unsupportedVersions.export",
            nvc =>
            {
                Assert.Equal(Epoch.For(supportDate).ToString(), nvc["date_end_of_support"]);
                Assert.Equal(Epoch.For(sessionDate).ToString(), nvc["date_sessions_started"]);
            });
    }
}