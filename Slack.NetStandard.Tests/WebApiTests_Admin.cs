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
            var response = await Utility.CheckApi(
                c => c.Admin.Apps.ApproveApp("ABC", "DEF"),
                "admin.apps.approve",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                }, WebApiResponse.Success());
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Admin_ApproveRequest()
        {
            var response = await Utility.CheckApi(
                c => c.Admin.Apps.ApproveRequest("ABC", "DEF"),
                "admin.apps.approve",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("request_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                }, WebApiResponse.Success());
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Admin_RestrictApp()
        {
            var response = await Utility.CheckApi(
                c => c.Admin.Apps.RestrictApp("ABC", "DEF"),
                "admin.apps.restrict",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                }, WebApiResponse.Success());
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Admin_RestrictRequest()
        {
            var response = await Utility.CheckApi(
                c => c.Admin.Apps.RestrictRequest("ABC", "DEF"),
                "admin.apps.restrict",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("request_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                }, WebApiResponse.Success());
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Admin_ListAppRequests()
        {
            var response = await Utility.CheckApi(
                c => c.Admin.Apps.ListAppRequests(new AppRequestFilter
                {
                    Limit = 20
                }),
                "admin.apps.requests.list",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                }, Utility.ExampleFileContent<ListAppRequestResponse>("Web_AdminAppsRequestsList.json"));
            Assert.True(response.OK);
            var appRequest = Assert.Single(response.AppRequests);
            Assert.Equal("A061BL8RQ0", appRequest.App.ID);
            Assert.Single(appRequest.Scopes);
        }

        [Fact]
        public async Task Admin_ListAppApproved()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ListApprovedApps(new AppFilter
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
                c => c.Admin.Apps.ListRestrictedApps(new AppFilter
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
    }
}
