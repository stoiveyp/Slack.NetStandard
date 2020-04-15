using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListAppRequestResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("app_requests",NullValueHandling = NullValueHandling.Ignore)]
        public AppRequest[] AppRequests { get; set; }
    }
}
