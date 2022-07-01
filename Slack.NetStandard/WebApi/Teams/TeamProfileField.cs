using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class TeamProfileField
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("ordering",NullValueHandling = NullValueHandling.Ignore)]
        public int? Ordering { get; set; }

        [JsonProperty("label",NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("hint",NullValueHandling = NullValueHandling.Ignore)]
        public string Hint { get; set; }

        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("possible_values",NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
        public string[] PossibleValues { get; set; }

        [JsonProperty("options",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,object> Options { get; set; }

        [JsonProperty("is_hidden",NullValueHandling = NullValueHandling.Ignore)]
        public int? Is_hidden { get; set; }
    }
}