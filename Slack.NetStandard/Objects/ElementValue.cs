using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Objects
{
    public class ElementValue
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("selected_option",NullValueHandling = NullValueHandling.Ignore)]
        public IOption SelectedOption { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}