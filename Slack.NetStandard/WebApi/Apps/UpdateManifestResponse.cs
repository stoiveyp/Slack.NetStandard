using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps
{
    public class UpdateManifestResponse:WebApiResponse
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("permissions_updated")]
        public bool PermissionsUpdated { get; set; }
    }
}
