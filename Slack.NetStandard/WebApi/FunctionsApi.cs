namespace Slack.NetStandard.WebApi;

internal class FunctionsApi : IFunctionsApi
{
    private readonly IWebApiClient _client;

    public FunctionsApi(IWebApiClient client)
    {
        _client = client;
        WorkflowSteps = new WorkflowStepsApi(client);
    }

    public IWorkflowStepsApi WorkflowSteps { get; }
}