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
    }
}
