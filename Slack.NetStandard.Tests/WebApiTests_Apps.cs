using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Apps
    {
        [Fact]
        public async Task Apps_Uninstall()
        {
            await Utility.AssertEncodedWebApi(c => c.Apps.Uninstall("clientid", "secret"), "apps.uninstall", nvc =>
            {
                Assert.Equal("clientid", nvc["client_id"]);
                Assert.Equal("secret", nvc["client_secret"]);
            });
        }
    }
}
