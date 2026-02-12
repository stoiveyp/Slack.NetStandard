using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System.Collections.Generic;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    [JsonConverter(typeof(BooleanOptionConverter))]
    public class BooleanOptions
    {
        [JsonProperty("type")]
        public virtual string Type { get; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}