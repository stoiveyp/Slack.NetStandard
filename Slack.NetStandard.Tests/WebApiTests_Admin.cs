using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Chat;
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
    }
}
