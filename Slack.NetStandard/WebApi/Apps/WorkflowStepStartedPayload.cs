using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowStepStartedPayload
{
    [JsonProperty("functionId")]
    public string FunctionId { get; set; }

    [JsonProperty("total_steps")]
    public int TotalSteps { get; set; }

    [JsonProperty("current_step")]
    public int CurrentStep { get; set; }

    [JsonProperty("function_name")]
    public string FunctionName { get; set; }

    [JsonProperty("function_execution_id")]
    public string FunctionExecutionId { get; set; }
}