using Newtonsoft.Json;
using Slack.NetStandard.WebApi.Apps.Manifest;

namespace Slack.NetStandard.WebApi.Apps
{
    public class ExportManifestResponse:WebApiResponse
    {
        [JsonProperty("manifest",NullValueHandling = NullValueHandling.Ignore)]
        public ManifestDefinition Manifest { get; set; }
    }
}
