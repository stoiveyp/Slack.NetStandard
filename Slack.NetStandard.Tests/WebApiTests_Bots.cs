using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Bots
    {
        [Fact]
        public async Task Bots_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Bots.Info("ABCDEF"), "bots.info", "Web_BotInfoResponse.json",nvc =>
            {
                Assert.Equal("ABCDEF", nvc["bot"]);
            });
        }
    }
}
