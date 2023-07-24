using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Functions;

public class StepVersion
{
    [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("workflow_id",NullValueHandling = NullValueHandling.Ignore)]
    public string WorkflowId { get; set; }

    [JsonProperty("step_id",NullValueHandling = NullValueHandling.Ignore)]
    public string StepId { get; set; }

    [JsonProperty("is_deleted",NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsDeleted { get; set; }

    [JsonProperty("workflow_version_created",NullValueHandling = NullValueHandling.Ignore)]
    public string WorkflowVersionCreated { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }
}