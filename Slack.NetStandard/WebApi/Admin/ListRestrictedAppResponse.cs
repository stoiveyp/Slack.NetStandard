using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListRestrictedAppResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("restricted_apps", NullValueHandling = NullValueHandling.Ignore)]
        public ResolvedApp[] Apps { get; set; }
    }
}