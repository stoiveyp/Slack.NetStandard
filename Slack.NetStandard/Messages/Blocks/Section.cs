using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Section:IMessageBlock
    {
        [JsonProperty("type")] public string Type => "section";

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public Text Text { get; set; }
    }
}
