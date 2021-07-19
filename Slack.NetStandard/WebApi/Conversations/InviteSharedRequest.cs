using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class InviteSharedRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("user_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] UserIds { get; set; }

        [JsonProperty("emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Emails { get; set; }

        [JsonProperty("external_limited", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExternalLimited { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("tracking_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingId { get; set; }
    }
}
