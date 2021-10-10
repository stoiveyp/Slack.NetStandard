using System.Threading.Tasks;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Apps.Manifest;
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
        public async Task Create()
        {
            var manifest = Utility.ExampleFileContent<ManifestDefinition>("Web_AppsManifestDefinition.json");
            await Utility.AssertWebApi(sc => sc.Apps.Manifest.Create(manifest), "apps.manifest.create",
                "Web_AppsManifestCreate.json", jo =>
                {
                    Assert.Equal(JsonConvert.SerializeObject(manifest), jo.Value<string>("manifest"));
                });
        }

        [Fact]
        public async Task Update()
        {
            var manifest = Utility.ExampleFileContent<ManifestDefinition>("Web_AppsManifestDefinition.json");
            await Utility.AssertWebApi(sc => sc.Apps.Manifest.Update("abc123", manifest), "apps.manifest.update",
                "Web_AppsManifestUpdate.json", jo =>
                {
                    Assert.Equal("abc123", jo.Value<string>("app_id"));
                    Assert.Equal(JsonConvert.SerializeObject(manifest), jo.Value<string>("manifest"));
                });
        }

        [Fact]
        public async Task Delete()
        {
            await Utility.AssertWebApi(sc => sc.Apps.Manifest.Delete("abc123"), "apps.manifest.delete",
                jo =>
                {
                    Assert.Equal("abc123", jo.Value<string>("app_id"));
                });
        }

        [Fact]
        public async Task Export()
        {
            await Utility.AssertWebApi(sc => sc.Apps.Manifest.Export("abc123"), "apps.manifest.export",
                "Web_AppsManifestExport.json", jo =>
                {
                    Assert.Equal("abc123", jo.Value<string>("app_id"));
                });
        }

        [Fact]
        public async Task Validate()
        {
            var manifest = Utility.ExampleFileContent<ManifestDefinition>("Web_AppsManifestDefinition.json");
            await Utility.AssertWebApi(sc => sc.Apps.Manifest.Validate(manifest), "apps.manifest.validate",
                jo =>
                {
                    Assert.Equal(JsonConvert.SerializeObject(manifest), jo.Value<string>("manifest"));
                });
        }
    }
}
