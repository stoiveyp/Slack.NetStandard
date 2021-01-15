using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Apps;
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

        [Fact]
        public async Task Apps_Authorizations()
        {
            await Utility.AssertEncodedWebApi(c => c.Apps.ListAuthorizations("C1234", "token", 10), "apps.event.authorizations.list", "Web_AdminAppsAuthorizations.json", nvc =>
            {
                Assert.Equal("C1234", nvc["event_context"]);
                Assert.Equal("token", nvc["cursor"]);
                Assert.Equal(10.ToString(), nvc["limit"]);
            });
        }

        [Fact]
        public async Task Apps_ConnectionOpen()
        {
            await Utility.AssertEncodedWebApi(c => c.Apps.OpenConnection(), "apps.connections.open", "Web_AppsConnectionsOpen.json", _ => {});
        }
    }
}
