using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class OptionGroup
    {
        [JsonProperty("label",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Label { get; set; }

        [JsonProperty("options",NullValueHandling = NullValueHandling.Ignore)]
        public IList<Option> Options { get; set; }
    }
}