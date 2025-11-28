using Slack.NetStandard.WebApi.SlackLists;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_SlackListsAccess
    {
        [Fact]
        public async Task SetChannels()
        {
            await Utility.AssertWebApi(c => c.SlackLists.Access.SetChannels(
                "F123456",
                ListAccessLevel.Write,
                "C1234"
                ), "slackLists.access.set", jo =>
                {
                    Assert.Equal("F123456", jo.Value<string>("list_id"));
                    Assert.Equal("write", jo.Value<string>("access_level"));
                    jo.CompareJArray("channel_ids", "C1234");
                });
        }

        [Fact]
        public async Task SetUsers()
        {
            await Utility.AssertWebApi(c => c.SlackLists.Access.SetUsers(
                "F123456",
                ListAccessLevel.Owner,
                "U1234"
                ), "slackLists.access.set", jo =>
                {
                    Assert.Equal("F123456", jo.Value<string>("list_id"));
                    Assert.Equal("owner", jo.Value<string>("access_level"));
                    jo.CompareJArray("user_ids", "U1234");
                });
        }

        [Fact]
        public async Task DeleteChannels()
        {
            await Utility.AssertWebApi(c => c.SlackLists.Access.DeleteChannels(
                "F123456",
                "C1234"
                ), "slackLists.access.delete", jo =>
                {
                    Assert.Equal("F123456", jo.Value<string>("list_id"));
                    jo.CompareJArray("channel_ids", "C1234");
                });
        }

        [Fact]
        public async Task DeleteUsers()
        {
            await Utility.AssertWebApi(c => c.SlackLists.Access.DeleteUsers(
                "F123456",
                "U1234"
                ), "slackLists.access.delete", jo =>
                {
                    Assert.Equal("F123456", jo.Value<string>("list_id"));
                    jo.CompareJArray("user_ids", "U1234");
                });
        }
    }
}