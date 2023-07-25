namespace Slack.NetStandard.WebApi;

internal class AdminAuditAnomalyApi : IAdminAuditAnomalyApi
{
    public AdminAuditAnomalyApi(IWebApiClient client)
    {
        Allow = new AdminAuditAnomalyAllowApi(client);
    }

    public IAdminAuditAnomalyAllowApi Allow { get; }
}