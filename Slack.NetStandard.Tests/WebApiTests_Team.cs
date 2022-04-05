using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;
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
        public async Task Team_InfoEmpty()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.Info(), "team.info", "Web_TeamInfo.json", Assert.Empty);
        }

        [Fact]
        public async Task Team_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.Info("T12345"), "team.info", "Web_TeamInfo.json", nvc =>
            {
                Assert.Equal("T12345", nvc["team"]);
            });
        }

        [Fact]
        public async Task Team_InfoDomain()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.Info(null,"T12345"), "team.info", "Web_TeamInfo.json", nvc =>
            {
                Assert.Equal("T12345", nvc["domain"]);
            });
        }

        [Fact]
        public async Task Team_IntegrationLogs()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.IntegrationLogs(new IntegrationLogRequest
            {
                ChangeType = "added",
                Count=10,
                Page=1
            }), "team.integrationLogs", "Web_TeamIntegrationLogs.json", nvc =>
            {
                Assert.Equal(3,nvc.Count);
                Assert.Equal("added", nvc["change_type"]);
                Assert.Equal(10.ToString(), nvc["count"]);
                Assert.Equal(1.ToString(), nvc["page"]);
            });
        }

        [Fact]
        public async Task Team_ProfileGet()
        {
            await Utility.AssertEncodedWebApi(c => c.Team.GetProfile("all"), "team.profile.get", "Web_TeamProfileGet.json", nvc =>
            {
                Assert.Equal("all", nvc["visibility"]);
            });
        }

        [Fact]
        public async Task Team_BillingInfo()
        {
            var response = await Utility.AssertEncodedWebApi(c => c.Team.Billing.Info(), "team.billing.info", "Web_TeamBillingInfo.json", nvc =>
            {
                
            });
            Assert.Null(response.OtherFields);
        }
    }
}