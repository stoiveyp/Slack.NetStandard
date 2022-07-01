using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class Overflow:IMessageElement
    {
        public Overflow(){}

        public Overflow(string actionId, params Option[] options)
        {
            ActionId = actionId;
            Options = options.ToList();
        }

        [JsonProperty("type")] public string Type => nameof(Overflow).ToLower();

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("options")]
        public IList<Option> Options { get; set; } = new List<Option>();

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        public bool ShouldSerializeOptions() => Options.Any();
    }
}
