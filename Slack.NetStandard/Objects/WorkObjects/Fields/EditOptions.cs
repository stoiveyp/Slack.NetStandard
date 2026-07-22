using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class EditOptions
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("placeholder", NullValueHandling = NullValueHandling.Ignore)] 
        public PlainText Placeholder { get; set; }

        [JsonProperty("hint", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Hint { get; set; }

        [JsonProperty("optional", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Optional { get; set; }

        [JsonProperty("select", NullValueHandling = NullValueHandling.Ignore)]
        public SelectEditOptions Select { get; set; }

        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public NumberEditOptions Number { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public TextEditOptions Text { get; set; }

        [JsonProperty("boolean", NullValueHandling = NullValueHandling.Ignore)]
        public BooleanEditOptions Boolean { get; set; }
    }
}
