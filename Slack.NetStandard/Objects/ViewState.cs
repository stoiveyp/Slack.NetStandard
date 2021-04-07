using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects
{
    public class ViewState
    {
        [JsonProperty("values",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ViewStateConverter))]
        public Dictionary<string, Dictionary<string,ElementValue>> Values { get; set; }
    }
}