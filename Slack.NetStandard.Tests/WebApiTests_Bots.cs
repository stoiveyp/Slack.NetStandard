using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Bots
    {
        [Fact]
        public async Task Bots_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Bots.Info("ABCDEF", "T12345"), "bots.info",
                "Web_BotInfoResponse.json", nvc =>
                {
                    Assert.Equal("ABCDEF", nvc["bot"]);
                    Assert.Equal("T12345", nvc["team_id"]);
                });
        }
    }
}
