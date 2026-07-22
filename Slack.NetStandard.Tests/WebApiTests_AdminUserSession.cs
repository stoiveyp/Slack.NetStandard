using Slack.NetStandard.WebApi.Admin;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminUserSession
{
    [Fact]
    public async Task Admin_UserSessionClearSettings()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.Session.ClearSettings(new[] { "U123", "U234" }),
            "admin.users.session.clearSettings", jo =>
            {
                jo.CompareJArray("user_ids", "U123", "U234");
            });
    }

    [Fact]
    public async Task Admin_UserSessionGetSettings()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Users.Session.GetSettings(new[] { "U123", "U234" }),
            "admin.users.session.getSettings", "Web_AdminUserSessionSettings.json", jo =>
            {
                jo.CompareJArray("user_ids", "U123", "U234");
            });
        var settings = Assert.Single(response.SessionSettings);
        Assert.True(settings.DesktopAppBrowserQuit);
        Assert.Equal(315569520, settings.Duration);
    }

    [Fact]
    public async Task Admin_UserSessionReset()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Users.Session.Reset("ABCDEF", SessionType.WebOnly),
            "admin.users.session.reset",
            nvc =>
            {
                Assert.Equal("ABCDEF", nvc["user_id"]);
                Assert.Equal("true", nvc["web_only"]);
            });
    }

    [Fact]
    public async Task Admin_UserSessionResetBulk()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.Session.ResetBulk(new []{ "U1234", "U2345", "U3456" }, SessionType.MobileOnly),
            "admin.users.session.resetBulk",
            jo =>
            {
                jo.CompareJArray("user_ids", "U1234", "U2345", "U3456");
                Assert.True(jo.Value<bool>("mobile_only"));
            });
    }

    [Fact]
    public async Task Admin_UserSessionList()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Users.Session.List(new ListSessionRequest
        {
            Cursor = "C1234",
            Limit = 6,
            TeamId = "T123",
            UserId = "U123"
        }),
            "admin.users.session.list", "Web_AdminUserSessionList.json",
            jo =>
            {
                Assert.Equal("C1234", jo.Value<string>("cursor"));
                Assert.Equal("T123", jo.Value<string>("team_id"));
                Assert.Equal("U123", jo.Value<string>("user_id"));
                Assert.Equal(6, jo.Value<int>("limit"));
            });

        var session = Assert.Single(response.ActiveSessions);
        Assert.Equal("U012S9M77JP", session.UserId);
        Assert.Equal("E011E2SBBFC", session.TeamId);
        Assert.Equal(1112275520242, session.SessionId);

        var recent = session.Recent;
        Assert.Equal("Intel", recent.DeviceHardware);
        Assert.Equal("OS X", recent.OS);
        Assert.Equal("10.15.7", recent.OsVersion);
        Assert.Equal("91.0.4472.77", recent.SlackClientVersion);
        Assert.Equal("24.6.145.138", recent.IP);
    }

    [Fact]
    public async Task Admin_UserSessionInvalidate()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.Session.Invalidate("S123", "T123"),
            "admin.users.session.invalidate",
            jo =>
            {
                Assert.Equal("S123", jo.Value<string>("session_id"));
                Assert.Equal("T123", jo.Value<string>("team_id"));
            });
    }

    [Fact]
    public async Task Admin_UserSessionSetSettings()
    {
        await Utility.AssertWebApi(c => c.Admin.Users.Session.SetSettings(new[] { "U123", "U234" },true,1234),
            "admin.users.session.setSettings",  jo =>
            {
                jo.CompareJArray("user_ids", "U123", "U234");
                Assert.True(jo.Value<bool>("desktop_app_browser_quit"));
                Assert.Equal(1234,jo.Value<long>("duration"));
            });
    }
}