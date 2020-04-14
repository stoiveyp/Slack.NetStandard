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
            var response = await Utility.CheckApi(
                c => c.View.Publish("ABC", new View(),"123456789"),
                "views.publish",
                jobject =>
                {
                    Assert.Equal(3, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("user_id"));
                    Assert.NotNull(jobject.Value<JObject>("view"));
                    Assert.Equal("123456789", jobject.Value<string>("hash"));
                }, Utility.ExampleFileContent<ViewResponse>("Web_ViewsPublish.json"));
            Assert.True(response.OK);
            Assert.Equal("VMHU10V25",response.View.ID);
        }
    }
}
