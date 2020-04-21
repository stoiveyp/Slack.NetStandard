using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    internal class AdminInviteRequestDecision
    {
        [JsonProperty("invite_request_id", NullValueHandling = NullValueHandling.Ignore)]
        public string InviteRequestId { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}