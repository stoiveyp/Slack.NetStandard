using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class User : SlackId
    {
        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty("real_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RealName { get; set; }

        [JsonProperty("tz", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; }

        [JsonProperty("tz_label", NullValueHandling = NullValueHandling.Ignore)]
        public string TimezoneLabel { get; set; }

        [JsonProperty("tz_offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimezoneOffset { get; set; }

        [JsonProperty("profile", NullValueHandling = NullValueHandling.Ignore)]
        public UserProfile Profile { get; set; }

        [JsonProperty("is_admin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAdmin { get; set; }

        [JsonProperty("is_owner", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOwner { get; set; }

        [JsonProperty("is_primary_owner", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrimaryOwner { get; set; }

        [JsonProperty("is_restricted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRestricted { get; set; }

        [JsonProperty("is_ultra_restricted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUltraRestricted { get; set; }

        [JsonProperty("is_bot", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsBot { get; set; }

        [JsonProperty("is_stranger", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsStranger { get; set; }

        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }

        [JsonProperty("is_app_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAppUser { get; set; }

        [JsonProperty("is_invited_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInvitedUser { get; set; }

        [JsonProperty("is_email_confirmed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEmailConfirmed { get; set; }
        
        [JsonProperty("who_can_share_contact_card", NullValueHandling = NullValueHandling.Ignore)]
        public string WhoCanShareContactCard { get; set; }

        [JsonProperty("has_2fa", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Has2FA { get; set; }

        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }
        
        [JsonProperty("enterprise_user", NullValueHandling = NullValueHandling.Ignore)]
        public EnterpriseUser EnterpriseUser { get; set; }
    }
}