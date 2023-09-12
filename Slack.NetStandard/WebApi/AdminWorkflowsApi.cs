namespace Slack.NetStandard.WebApi;

internal class AdminWorkflowsApi : IAdminWorkflowsApi
{
    private readonly IWebApiClient _client;
    public AdminWorkflowsApi(IWebApiClient client)
    {
        _client = client;
    }
}