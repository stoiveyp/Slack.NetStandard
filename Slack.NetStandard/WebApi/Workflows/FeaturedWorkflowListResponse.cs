using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Workflows
{
    public class FeaturedWorkflowListResponse:WebApiResponse
    {
        [JsonProperty("featured_workflows")]
        public FeaturedWorkflow[] featuredWorkflows { get; set; }
    }
}
