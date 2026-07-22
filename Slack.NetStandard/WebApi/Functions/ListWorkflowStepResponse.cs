using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Functions;

public class ListWorkflowStepResponse : WebApiResponse
{
    [JsonProperty("steps_versions",NullValueHandling = NullValueHandling.Ignore)]
    public StepVersion[] StepVersions { get; set; }
}