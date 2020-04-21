using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Team
    {
        [Fact]
        public async Task Team_AccessLogs()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.AccessLogs(1234,10,1), "team.accessLogs", "Web_TeamAccessLogs.json", nvc =>
            {
                Assert.Equal(1234.ToString(), nvc["before"]);
                Assert.Equal(10.ToString(), nvc["count"]);
                Assert.Equal(1.ToString(), nvc["page"]);
            });
        }

        [Fact]
        public async Task Team_BillableInfo()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.BillableInfo("U1234"), "team.billableInfo", "Web_TeamBillableInfo.json", nvc =>
            {
                Assert.Equal("U1234", nvc["user"]);
            });
        }

        [Fact]
        public async Task Team_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.Info("T12345"), "team.info", "Web_TeamInfo.json", nvc =>
            {
                Assert.Equal("T12345", nvc["team"]);
            });
        }
    }
}