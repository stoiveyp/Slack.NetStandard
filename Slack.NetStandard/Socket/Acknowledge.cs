using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Socket
{
    public class Acknowledge:Acknowledge<object>
    {

    }

    public class Acknowledge<T>
    {
        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; set; }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public T Payload { get; set; }
    }
}
