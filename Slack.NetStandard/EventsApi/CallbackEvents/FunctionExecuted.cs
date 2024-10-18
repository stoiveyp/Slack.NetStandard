using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects;
using Slack.NetStandard.Objects.Workflows;
using System.Collections;

namespace Slack.NetStandard.EventsApi.CallbackEvents;

public class FunctionExecuted : CallbackEvent
{
    public const string EventType = "function_executed";

    [JsonProperty("workflow_execution_id", NullValueHandling = NullValueHandling.Ignore)]
    public string WorkflowExecutionId { get; set; }

    [JsonProperty("function_execution_id", NullValueHandling = NullValueHandling.Ignore)]
    public string FunctionExecutionId { get; set; }

    [JsonProperty("bot_access_token", NullValueHandling = NullValueHandling.Ignore)]
    public string BotAccessToken { get; set; }

    [JsonProperty("function", NullValueHandling = NullValueHandling.Ignore)]
    public Function Function { get; set; }

    [JsonProperty("inputs", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(WorkflowInputConverter))]
    public JObject[] Inputs { get; set; }
}