using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class WorkflowSearchResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("total_found",NullValueHandling = NullValueHandling.Ignore)]
    public int? TotalFound { get; set; }

    [JsonProperty("workflows",NullValueHandling = NullValueHandling.Ignore)]
    public Objects.Workflows.Workflow[] Workflow { get; set; }
}