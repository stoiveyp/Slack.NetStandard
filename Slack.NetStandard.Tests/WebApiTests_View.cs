using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Objects;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.View;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_View
    {
        [Fact]
        public async Task View_Publish()
        {
            await Utility.AssertWebApi(
                c => c.View.Publish("ABC", new View(),"123456789"),
                "views.publish", "Web_ViewsPublish.json",
                jobject =>
                {
                    Assert.Equal(3, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("user_id"));
                    Assert.NotNull(jobject.Value<JObject>("view"));
                    Assert.Equal("123456789", jobject.Value<string>("hash"));
                });
        }

        [Fact]
        public async Task ViewOpen()
        {
            var response = await Utility.AssertWebApi(
                c => c.View.Open("12345.98765.abcd2358fdea", new View{Type = "modal"}),
                "views.open", "Web_ViewsPublish.json",
                jobject =>
                {
                    Assert.NotNull(jobject.Value<JObject>("view"));
                    Assert.Equal("12345.98765.abcd2358fdea", jobject.Value<string>("trigger_id"));
                });
        }

        [Fact]
        public async Task ViewPublish()
        {
            var response = await Utility.AssertWebApi(
                c => c.View.Push("12345.98765.abcd2358fdea", new View { Type = "modal" }),
                "views.push", "Web_ViewsPublish.json",
                jobject =>
                {
                    Assert.NotNull(jobject.Value<JObject>("view"));
                    Assert.Equal("12345.98765.abcd2358fdea", jobject.Value<string>("trigger_id"));
                });
        }

        [Fact]
        public async Task UpdateExternal()
        {
            var response = await Utility.AssertWebApi(
                c => c.View.UpdateByExternalId("12345.98765.abcd2358fdea", new View { Type = "modal" }),
                "views.update", "Web_ViewsPublish.json",
                jobject =>
                {
                    Assert.NotNull(jobject.Value<JObject>("view"));
                    Assert.Equal("12345.98765.abcd2358fdea", jobject.Value<string>("external_id"));
                });
        }

        [Fact]
        public async Task UpdateView()
        {
            var response = await Utility.AssertWebApi(
                c => c.View.UpdateByViewId("12345.98765.abcd2358fdea", new View { Type = "modal" }),
                "views.update", "Web_ViewsPublish.json",
                jobject =>
                {
                    Assert.NotNull(jobject.Value<JObject>("view"));
                    Assert.Equal("12345.98765.abcd2358fdea", jobject.Value<string>("view_id"));
                });
        }
    }
}
