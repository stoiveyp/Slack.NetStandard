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
                c => c.Admin.Apps.ApproveApp("ABC","DEF"),
                "admin.apps.approve",
                jobject =>
                {
                    Assert.Equal(2,jobject.Children().Count());
                    Assert.Equal("ABC",jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                },WebApiResponse.Success());
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
                    Assert.Equal(1, jobject.Children().Count());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                }, Utility.ExampleFileContent<ListAppRequestResponse>("Web_AdminAppsRequestsList.json"));
            Assert.True(response.OK);
            var appRequest = Assert.Single(response.AppRequests);
            Assert.Equal("A061BL8RQ0", appRequest.App.ID);
            Assert.Single(appRequest.Scopes);
        }
    }
}
