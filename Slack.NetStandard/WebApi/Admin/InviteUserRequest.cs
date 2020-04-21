using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class InviteUserRequest
    {
        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("channel_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelIds { get; set; }

        [JsonProperty("custom_message",NullValueHandling = NullValueHandling.Ignore)]
        public string CustomMessage { get; set; }

        [JsonProperty("guest_expiration_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp GuestExpiration { get; set; }

        [JsonProperty("is_restricted",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRestricted { get; set; }

        [JsonProperty("is_ultra_restricted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUltraRestricted { get; set; }

        [JsonProperty("full_name",NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty("resend",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Resend { get; set; }
    }
}