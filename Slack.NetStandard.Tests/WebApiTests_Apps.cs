using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Apps;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Apps
    {
        [Fact]
        public async Task Apps_ActivitiesList()
        {
            var response = await Utility.AssertWebApi(c => c.Apps.ListActivities(new ListActivitiesRequest("A12345")
            {
                Limit = 5,
                MinLogLevel = LogLevel.Warn,
                Source = "STUFF"
            }), "apps.activities.list", "Web_AppsListActivitiesResponse.json", jo =>
            {
                Assert.Equal(5, jo.Value<int>("limit"));
                Assert.Equal("warn", jo.Value<string>("min_log_level"));
                Assert.Equal("STUFF", jo.Value<string>("source"));
            });

            Assert.IsType<Activity<FunctionExecutionStartedPayload>>(Assert.Single(response.Activities));
        }

        [Fact]
        public async Task Apps_ExternalAuthGet()
        {
            var tokenVolume =
                "00D3j00000025Zh!AQ4AQMAl46qme3wdZiKo5j3WHcJujZXoB0FtsFuC5JxWZdje2aiecF9vY5KdY5wTPUZIYBekIraDWuw_u_ZUgeIA1.opF6L9";
            var response = await Utility.AssertEncodedWebApi(c => c.Apps.GetExternalAuth("ET123", true), "apps.auth.external.get", nvc =>
            {
                Assert.Equal("ET123", nvc["external_token_id"]);
                Assert.Equal("true", nvc["force_refresh"]);
            }, new ExternalTokenResponse { OK = true, ExternalToken = tokenVolume });
            Assert.Equal(response.ExternalToken, tokenVolume);
        }

        [Fact]
        public async Task Apps_ExternalAuthDelete()
        {
            await Utility.AssertEncodedWebApi(c => c.Apps.DeleteExternalAuth("A123", "T123", "P123"), "apps.auth.external.delete", nvc =>
            {
                Assert.Equal("A123", nvc["app_id"]);
                Assert.Equal("T123", nvc["external_token_id"]);
                Assert.Equal("P123", nvc["provider_key"]);
            });
        }

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
            await Utility.AssertEncodedWebApi(c => c.Apps.OpenConnection(), "apps.connections.open", "Web_AppsConnectionsOpen.json", _ => { });
        }
    }
}
