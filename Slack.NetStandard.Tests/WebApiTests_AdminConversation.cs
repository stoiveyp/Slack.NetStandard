using Slack.NetStandard.WebApi.Admin;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminConversation
{
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
}