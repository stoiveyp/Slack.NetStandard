using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListApprovedAppResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("approved_apps",NullValueHandling = NullValueHandling.Ignore)]
        public ResolvedApp[] Apps { get; set; }
    }
}