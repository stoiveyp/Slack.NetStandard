using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Objects
{
    public class Invite
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("date_created",NullValueHandling = NullValueHandling.Ignore)]
        public long DateCreated { get; set; }

        [JsonProperty("date_invalid",NullValueHandling = NullValueHandling.Ignore)]
        public long DateInvalid { get; set; }

        [JsonProperty("inviting_team",NullValueHandling = NullValueHandling.Ignore)]
        public Team InvitingTeam { get; set; }

        [JsonProperty("inviting_user",NullValueHandling = NullValueHandling.Ignore)]
        public User InvitingUser { get; set; }

        [JsonProperty("recipient_email",NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientEmail { get; set; }

        [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("recipient_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientUserId { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}
