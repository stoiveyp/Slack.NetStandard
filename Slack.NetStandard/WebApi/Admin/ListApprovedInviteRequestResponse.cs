using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListApprovedInviteRequestResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("approved_requests", NullValueHandling = NullValueHandling.Ignore)]
        public InviteRequest[] ApprovedRequests { get; set; }
    }
}