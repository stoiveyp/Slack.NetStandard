using Slack.NetStandard.WebApi.Workflows;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IWorkflowsTriggersPermissionsApi
    {
        Task<WorkflowTriggerPermisssionResponse> Add(WorkflowTriggerPermissionManipulationRequest request);
        Task<WorkflowTriggerPermisssionResponse> Remove(WorkflowTriggerPermissionManipulationRequest request);
        Task<WorkflowTriggerPermisssionResponse> Set(WorkflowTriggerPermissionRequest request);

        Task<WorkflowTriggerPermisssionResponse> List(string triggerId);
    }
}