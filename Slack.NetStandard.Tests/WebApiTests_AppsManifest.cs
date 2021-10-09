using System.Threading.Tasks;
using Slack.NetStandard.WebApi;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_AppsManifest
    {
        [Fact]
        public void AppsManifest_Errors()
        {
            Utility.AssertType<WebApiResponse>("Web_AppsManifestErrors.json");
        }

        [Fact]
        public async Task AppsManifest_Serialises()
        {
            var response = await Utility.AssertEncodedWebApi(sc => sc.Apps.Manifest.Export("xxx"), "apps.manifest.export",
                "Web_AppsManifestExport.json", nvc =>
                {
                    Assert.Equal("xxx",nvc["app_id"]);
                });
            Assert.Null(response.OtherFields);
        }
    }
}
