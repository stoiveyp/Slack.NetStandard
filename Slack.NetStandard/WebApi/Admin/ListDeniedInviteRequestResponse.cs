using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListDeniedInviteRequestResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("denied_requests",NullValueHandling = NullValueHandling.Ignore)]
        public InviteRequest[] DeniedRequests { get; set; }
    }
}