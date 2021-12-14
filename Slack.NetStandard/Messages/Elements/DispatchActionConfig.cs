using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Messages.Elements
{
    public class DispatchActionConfig
    {
        public DispatchActionConfig(ActionTrigger[] triggers)
        {
            TriggerActionsOn = triggers;
        }

        [JsonProperty("trigger_actions_on", NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
        public ActionTrigger[] TriggerActionsOn { get; set; }
    }
}