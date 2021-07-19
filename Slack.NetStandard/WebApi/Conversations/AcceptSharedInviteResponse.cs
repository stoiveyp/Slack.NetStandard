using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class AcceptSharedInviteResponse : WebApiResponse
    {
        [JsonProperty("implicit_approval",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ImplicitApproval { get; set; }

        [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelId { get; set; }

        [JsonProperty("invite_id",NullValueHandling = NullValueHandling.Ignore)]
        public string InviteId { get; set; }
    }
}