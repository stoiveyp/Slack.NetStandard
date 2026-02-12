using Newtonsoft.Json;
using Slack.NetStandard.Objects.WorkObjects;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Messages
{
    public class MessageMetadata
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_payload",NullValueHandling = NullValueHandling.Ignore)]
        public object EventPayload { get; set; }

        [JsonProperty("entities")]
        public List<MetadataEntity> Entities { get; set; } = [];

        public bool ShouldSerializeEntities() => Entities?.Any() ?? false;
    }
}
