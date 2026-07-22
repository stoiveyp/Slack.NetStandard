using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Functions
{
    public class ListWorkflowStepRequest
    {
        public ListWorkflowStepRequest(){}

        public ListWorkflowStepRequest(string functionId)
        {
            FunctionId = functionId;
        }

        [JsonProperty("function_id",NullValueHandling = NullValueHandling.Ignore)]
        public string FunctionId { get; set; }

        [JsonProperty("workflow",NullValueHandling = NullValueHandling.Ignore)]
        public string Workflow { get; set; }

        [JsonProperty("workflow_app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowAppId { get; set; }

        [JsonProperty("workflow_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowId { get; set; }
    }
}
