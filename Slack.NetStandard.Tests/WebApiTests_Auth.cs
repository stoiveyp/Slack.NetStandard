using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Auth
    {
        [Fact]
        public async Task Auth_RevokeToken()
        {
            await Utility.AssertEncodedWebApi(c => c.Auth.Revoke(true), "auth.revoke", "Web_AuthRevoke.json",nvc =>
            {
                Assert.Equal("true", nvc["test"]);
            });
        }

        [Fact]
        public async Task Auth_Test()
        {
            var response = await Utility.AssertEncodedWebApi(c => c.Auth.Test(), "auth.test", "Web_AuthTest.json", Assert.Empty);
            Assert.Null(response.OtherFields);
        }

        [Fact]
        public async Task Auth_TeamsList()
        {
            var response = await Utility.AssertWebApi(c => c.Auth.TeamsList(true,"C123",5), "auth.teams.list", "Web_AuthTeamsList.json",
                jo =>
                {
                    Assert.True(jo.Value<bool>("include_icon"));
                    jo.TestPaging("C123",5);
                });
            
            Assert.Equal(2,response.Teams.Length);
            Assert.True(response.Teams[0].Icon.Count > 0);
        }
    }
}
