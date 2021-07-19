using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ListConnectInviteResponse:WebApiResponse
    {
        [JsonProperty("invites",NullValueHandling = NullValueHandling.Ignore)]
        public InviteInformation[] Invites { get; set; }
    }
}
