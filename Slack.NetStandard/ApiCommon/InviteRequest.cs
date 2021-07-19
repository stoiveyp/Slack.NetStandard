using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.ApiCommon
{
    public class InviteRequest
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("email",NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("date_created",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateCreated { get; set; }

        [JsonProperty("requester_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] RequesterIds { get; set; }

        [JsonProperty("channel_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] ChannelIds { get; set; }

        [JsonProperty("invite_type",NullValueHandling = NullValueHandling.Ignore)]
        public string InviteType { get; set; }

        [JsonProperty("real_name",NullValueHandling = NullValueHandling.Ignore)]
        public string RealName { get; set; }

        [JsonProperty("date_expire",NullValueHandling = NullValueHandling.Ignore)]
        public long DateExpire { get; set; }

        [JsonProperty("request_reason",NullValueHandling = NullValueHandling.Ignore)]
        public string RequestReason { get; set; }

        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public TeamSummary Team { get; set; }
    }
}