using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class InviteSharedRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("user_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> UserIds { get; set; } = new List<string>();

        [JsonProperty("emails", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Emails { get; set; } = new List<string>();

        [JsonProperty("external_limited", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExternalLimited { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("tracking_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingId { get; set; }

        public bool ShouldSerializeUserIds() => UserIds?.Any() ?? false;
        public bool ShouldSerializeEmails() => Emails?.Any() ?? false;
    }
}
