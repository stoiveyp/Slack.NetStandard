namespace Slack.NetStandard.WebApi;

internal class AdminFunctionsApi : IAdminFunctionsApi
{
    private readonly IWebApiClient _client;
    public AdminFunctionsApi(IWebApiClient client)
    {
        _client = client;
    }
}