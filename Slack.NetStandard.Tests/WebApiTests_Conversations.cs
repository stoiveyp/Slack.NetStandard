using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Conversations;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Conversations
    {
        [Fact]
        public async Task Conversations_Archive()
        {
            var response = await Utility.CheckApi(c => c.Conversations.Archive("ABCDEF"), "conversations.archive",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal("ABCDEF", jobject.Value<string>("channel"));
                }, new WebApiResponse { OK = true });
            Assert.True(response.OK);
        }

        [Fact]
        public async Task Conversations_Close()
        {
            var response = await Utility.CheckApi(c => c.Conversations.Close("ABCDEF"), "conversations.close",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal("ABCDEF", jobject.Value<string>("channel"));
                }, new CloseConversationResponse { OK = true, Noop = true, AlreadyClosed = true });
            Assert.True(response.OK);
            Assert.True(response.AlreadyClosed);
            Assert.True(response.Noop);
        }
    }
}
