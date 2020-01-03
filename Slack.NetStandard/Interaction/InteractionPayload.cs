using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Interaction
{
    [JsonConverter(typeof(PayloadConverter))]
    public class InteractionPayload
    {
        [JsonProperty("type"),JsonConverter(typeof(StringEnumConverter))]
        public InteractionType Type { get; set; }

        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("team")]
        public PayloadTeam Team { get; set; }

        [JsonProperty("user")]
        public PayloadUser User { get; set; }

        [JsonProperty("channel")]
        public PayloadChannel Channel { get; set; }

        [JsonProperty("api_app_id")]
        public string ApiAppId { get; set; }

        [JsonProperty("actions",NullValueHandling = NullValueHandling.Ignore)]
        public PayloadAction[] Actions { get; set; }

        [JsonProperty("response_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseUrl { get; set; }
    }
}
