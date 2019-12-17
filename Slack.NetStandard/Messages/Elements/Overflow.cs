using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.Messages.Elements
{
    public class Overflow:IMessageElement
    {
        [JsonProperty("type")] public string Type => nameof(Overflow).ToLower();

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("options")]
        public IList<Option> Options { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }
}
