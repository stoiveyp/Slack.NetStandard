using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}