using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class FunctionExecutionStartedPayload
{
    [JsonProperty("function_name")]
    public string FunctionName { get; set; }

    [JsonProperty("function_type")]
    public string FunctionType { get; set; }
}