using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Socket
{
    [JsonConverter(typeof(EnvelopeConverter))]
    public class Envelope
    {
        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("accepts_response_payload")]
        public bool AcceptsResponsePayload { get; set; }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public object Payload { get; set; }

        [JsonProperty("retry_attempt", NullValueHandling = NullValueHandling.Ignore)]
        public int? RetryAttempt { get; set; }

        [JsonProperty("retry_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string RetryReason { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> Otherfields { get; set; }
    }
}
