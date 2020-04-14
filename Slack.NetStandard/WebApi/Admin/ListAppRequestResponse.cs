using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListAppRequestResponse:WebApiResponse
    {
        [JsonProperty("app_requests",NullValueHandling = NullValueHandling.Ignore)]
        public AppRequest[] AppRequests { get; set; }
    }

    public class ResolvedAppRequest : WebApiResponse { }
}
