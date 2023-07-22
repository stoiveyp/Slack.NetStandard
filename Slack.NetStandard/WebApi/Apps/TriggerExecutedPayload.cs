using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class TriggerExecutedPayload
{
    [JsonProperty("function_name")]
    public string FunctionName { get; set; }

    [JsonProperty("trigger")]
    public TriggerExecutedPayloadTrigger Trigger { get; set; }
}