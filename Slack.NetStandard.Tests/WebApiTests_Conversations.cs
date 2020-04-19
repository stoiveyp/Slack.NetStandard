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
            var response = await Utility.AssertWebApi(c => c.Conversations.Archive("ABCDEF"), "conversations.archive",
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
            var response = await Utility.AssertWebApi(c => c.Conversations.Close("ABCDEF"), "conversations.close",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal("ABCDEF", jobject.Value<string>("channel"));
                }, new CloseConversationResponse { OK = true, Noop = true, AlreadyClosed = true });
            Assert.True(response.OK);
            Assert.True(response.AlreadyClosed);
            Assert.True(response.Noop);
        }

        [Fact]
        public async Task Conversations_Create()
        {
            var response = await Utility.AssertWebApi(c => c.Conversations.Create("test this", true),
                "conversations.create", "Web_ConversationsCreate.json", j =>
                {
                    Assert.Equal("test this", j.Value<string>("name"));
                    Assert.True(j.Value<bool>("is_private"));
                });
        }

        [Fact]
        public async Task Conversations_History()
        {
            var request = new ConversationHistoryRequest
            {
                Channel= "C1234567890",
                Latest = "1234567890.123456"
            };
            await Utility.AssertWebApi(c => c.Conversations.History(request),
                "conversations.history", "Web_ConversationsHistory.json", j =>
                {
                    Assert.Equal("C1234567890", j.Value<string>("channel"));
                    Assert.Equal("1234567890.123456",j.Value<string>("latest"));
                });
        }
    }
}
