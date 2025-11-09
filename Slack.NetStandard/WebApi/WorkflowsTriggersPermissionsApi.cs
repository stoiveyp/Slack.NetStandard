using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Workflows;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class WorkflowsTriggersPermissionsApi : IWorkflowsTriggersPermissionsApi
    {
        private readonly IWebApiClient _client;
        public WorkflowsTriggersPermissionsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WorkflowTriggerPermisssionResponse> Add(WorkflowTriggerPermissionManipulationRequest request)
        {
            return _client.MakeJsonCall<WorkflowTriggerPermissionManipulationRequest, WorkflowTriggerPermisssionResponse>("workflows.triggers.permissions.add", request);
        }

        public Task<WorkflowTriggerPermisssionResponse> List(string triggerId)
        {
            return _client.MakeJsonCall<JObject,WorkflowTriggerPermisssionResponse>("workflows.triggers.permissions.list", 
                new JObject(new JProperty("trigger_id", triggerId))
            );
        }

        public Task<WorkflowTriggerPermisssionResponse> Remove(WorkflowTriggerPermissionManipulationRequest request)
        {
            return _client.MakeJsonCall<WorkflowTriggerPermissionManipulationRequest, WorkflowTriggerPermisssionResponse>("workflows.triggers.permissions.remove", request);
        }

        public Task<WorkflowTriggerPermisssionResponse> Set(WorkflowTriggerPermissionRequest request)
        {
            return _client.MakeJsonCall<WorkflowTriggerPermissionRequest, WorkflowTriggerPermisssionResponse>("workflows.triggers.permissions.set", request);
        }
    }
}