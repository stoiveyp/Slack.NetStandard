using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class InviteInformation
    {
        [JsonProperty("direction",NullValueHandling = NullValueHandling.Ignore)]
        public string Direction { get; set; }

        [JsonProperty("status",NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("date_last_updated",NullValueHandling = NullValueHandling.Ignore)]
        public long? LastUpdated { get; set; }

        [JsonProperty("invite_type",NullValueHandling = NullValueHandling.Ignore)]
        public string InviteType { get; set; }

        [JsonProperty("invite", NullValueHandling = NullValueHandling.Ignore)]
        public Invite Invite { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
