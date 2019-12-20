using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Conversations
    {
        [Fact]
        public async Task Conversations_Archive()
        {
            var response = await Utility.CheckApi(c => c.Conversations.Archive("ABCDEF"), "chat.postMessage",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal("ABCDEF", jobject.Value<string>("channel"));
                }, new WebApiResponse { OK = true });
            Assert.True(response.OK);
        }
    }
}
