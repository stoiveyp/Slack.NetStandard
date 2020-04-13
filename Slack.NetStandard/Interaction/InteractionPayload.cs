using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Interaction
{
    [JsonConverter(typeof(InteractionPayloadConverter))]
    public class InteractionPayload
    {
        [JsonProperty("type"),JsonConverter(typeof(StringEnumConverter))]
        public InteractionType Type { get; set; }

        [JsonProperty("user")]
        public PayloadUser User { get; set; }

        [JsonProperty("team")]
        public PayloadTeam Team { get; set; }

        [JsonProperty("api_app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ApiAppId { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
