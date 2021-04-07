using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.ApiCommon;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Interaction
{
    [JsonConverter(typeof(InteractionPayloadConverter))]
    public class InteractionPayload
    {
        [JsonProperty("type"),JsonConverter(typeof(StringEnumConverter))]
        public InteractionType Type { get; set; }

        [JsonProperty("user")]
        public UserSummary User { get; set; }

        [JsonProperty("team")]
        public TeamSummary Team { get; set; }

        [JsonProperty("api_app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ApiAppId { get; set; }

        [JsonProperty("token",NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        [JsonProperty("trigger_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TriggerId { get; set; }

        [JsonProperty("action_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ActionTimestamp { get; set; }

        [JsonProperty("enterprise", NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Enterprise { get; set; }

        [JsonProperty("is_enterprise_install", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEnterpriseInstall { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
