using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Teams
    {
        [Fact]
        public async Task Teams_AccessLogs()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.AccessLogs(1234,10,1), "team.accessLogs", "Web_TeamAccessLogs.json", nvc =>
            {
                Assert.Equal(1234.ToString(), nvc["before"]);
                Assert.Equal(10.ToString(), nvc["count"]);
                Assert.Equal(1.ToString(), nvc["page"]);
            });
        }
    }
}