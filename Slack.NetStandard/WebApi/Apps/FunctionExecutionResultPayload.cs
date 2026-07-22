using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class FunctionExecutionResultPayload
{
    [JsonProperty("function_name")]
    public string FunctionName { get; set; }

    [JsonProperty("error")]
    public string Error { get; set; }
}