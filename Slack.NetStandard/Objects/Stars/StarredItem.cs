using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects.Stars
{
    [JsonConverter(typeof(StarredItemConverter))]
    public class StarredItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}