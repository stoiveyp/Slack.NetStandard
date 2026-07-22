namespace Slack.NetStandard.WebApi;

public interface IFunctionsApi
{
    IWorkflowStepsApi WorkflowSteps { get; }
}