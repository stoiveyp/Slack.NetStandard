using System.Linq;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Admin;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Admin
    {
        [Fact]
        public async Task Admin_ApproveApp()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ApproveApp("ABC", "DEF"),
                "admin.apps.approve",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_ApproveRequest()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ApproveRequest("ABC", "DEF"),
                "admin.apps.approve",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("request_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_RestrictApp()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.RestrictApp("ABC", "DEF"),
                "admin.apps.restrict",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_RestrictRequest()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.RestrictRequest("ABC", "DEF"),
                "admin.apps.restrict",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("request_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_ListAppRequests()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ListAppRequests(new TeamRequestFilter
                {
                    Limit = 20
                }),
                "admin.apps.requests.list", "Web_AdminAppsRequestsList.json",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                });
        }

        [Fact]
        public async Task Admin_ListAppApproved()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ListApprovedApps(new TeamFilter
                {
                    Limit = 20,
                    Enterprise = "ABCDEF"
                }),
                "admin.apps.approved.list", "Web_AdminAppsApprovedList.json",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                    Assert.Equal("ABCDEF", jobject.Value<string>("enterprise_id"));
                });
        }

        [Fact]
        public async Task Admin_ListAppRestricted()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ListRestrictedApps(new TeamFilter
                {
                    Limit = 20,
                    Enterprise = "ABCDEF"
                }),
                "admin.apps.restricted.list", "Web_AdminAppsRestrictedList.json",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                    Assert.Equal("ABCDEF", jobject.Value<string>("enterprise_id"));
                });
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
        public async Task Admin_EmojiList()
        {
            await Utility.AssertEncodedWebApi(c => c.Admin.Emoji.List("ABCDEF"), "admin.emoji.list", "Web_AdminEmojiList.json",
                j => Assert.Equal("ABCDEF", j["cursor"]));
        }

        [Fact]
        public async Task Admin_EmojiAdd()
        {
            await Utility.AssertEncodedWebApi(c => c.Admin.Emoji.Add(":myemoji:", "urlGoesHere"), "admin.emoji.add",
                j =>
                {
                    Assert.Equal(":myemoji:", j["name"]);
                    Assert.Equal("urlGoesHere", j["url"]);
                });
        }

        [Fact]
        public async Task Admin_InviteRequestApprove()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.Approve("ABCDEF","DEFGHI"), "admin.inviteRequests.approve", 
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("invite_request_id"));
                    Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_InviteRequestDeny()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.Deny("ABCDEF", "DEFGHI"), "admin.inviteRequests.deny",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("invite_request_id"));
                    Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_InviteRequestList()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.ListInviteRequests(new TeamFilter()), "admin.inviteRequests.list",
                j =>
                {
                });
        }

        [Fact]
        public async Task Admin_InviteRequestListApproved()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.ListApprovedInviteRequests(new TeamFilter{Cursor="ABCDEF"}), "admin.inviteRequests.approved.list",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("cursor"));
                });
        }

        [Fact]
        public async Task Admin_InviteRequestListDenied()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.ListDeniedInviteRequests(new TeamFilter { Cursor = "ABCDEF" }), "admin.inviteRequests.denied.list",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("cursor"));
                });
        }

        [Fact]
        public async Task Admin_TeamsListAdmins()
        {
            await Utility.AssertEncodedWebApi(c => c.Admin.Teams.ListAdmins("ABCDEF", "DEFGHI", 20),
                "admin.teams.admins.list", "Web_AdminTeamsAdminList.json",
                nvc =>
                {
                    Assert.Equal("ABCDEF",nvc["team_id"]);
                    Assert.Equal("DEFGHI",nvc["cursor"]);
                    Assert.Equal("20",nvc["limit"]);
                });
        }

        [Fact]
        public async Task Admin_TeamsCreateRequest()
        {
            await Utility.AssertWebApi(c => c.Admin.Teams.Create(new TeamCreateRequest
                {
                    TeamDomain="test.com",
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
    }
}
