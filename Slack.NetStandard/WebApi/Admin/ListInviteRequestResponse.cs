using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;
using Slack.NetStandard.EventsApi.CallbackEvents;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListInviteRequestResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("invite_requests", NullValueHandling = NullValueHandling.Ignore)]
        public InviteRequest[] InviteRequests { get; set; }
    }
}
