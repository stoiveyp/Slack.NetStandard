using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class OptionGroup:IOption
    {
        [JsonProperty("label")]
        public PlainText Label { get; set; }

        [JsonProperty("options")]
        public IList<Option> Options { get; set; }
    }
}