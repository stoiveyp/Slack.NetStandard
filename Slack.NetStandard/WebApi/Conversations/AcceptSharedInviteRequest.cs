using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class AcceptSharedInviteRequest
    {
        [JsonProperty("channel_name")]
        public string ChannelName { get; set; }

        [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelId { get; set; }

        [JsonProperty("invite_id",NullValueHandling = NullValueHandling.Ignore)]
        public string InviteId { get; set; }

        [JsonProperty("is_private",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("free_trial_accepted",NullValueHandling = NullValueHandling.Ignore)]
        public bool? FreeTrialAccepted { get; set; }
    }
}
