using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowStepExecutionResultPayload
{
    [JsonProperty("inputs")]
    public Dictionary<string,object> Inputs { get; set; }

    [JsonProperty("function_id")]
    public string FunctionId { get; set; }

    [JsonProperty("exec_outcome")]
    public ExecOutcome ExecOutcome { get; set; }

    [JsonProperty("function_name")]
    public string FunctionName { get; set; }

    [JsonProperty("function_execution_id")]
    public string FunctionExecutionId { get; set; }
}