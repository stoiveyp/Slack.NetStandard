using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class ViewState
    {
        [JsonProperty("values",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Values { get; set; }
    }
}