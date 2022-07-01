using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Messages.Elements
{
    public class DispatchActionConfig
    {
        public DispatchActionConfig(){}

        public DispatchActionConfig(IEnumerable<ActionTrigger> triggers)
        {
            TriggerActionsOn = triggers.ToList();
        }

        [JsonProperty("trigger_actions_on", NullValueHandling = NullValueHandling.Ignore,
            ItemConverterType = typeof(StringEnumConverter))]
        public IList<ActionTrigger> TriggerActionsOn { get; set; } = new List<ActionTrigger>();

        public bool ShouldSerializeTriggerActionsOn() => TriggerActionsOn.Any();
    }
}