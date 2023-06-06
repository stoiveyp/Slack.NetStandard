using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

internal class AdminAuditAnomalyApi : IAdminAuditAnomalyApi
{
    public AdminAuditAnomalyApi(IWebApiClient client)
    {
        Allow = new AdminAuditAnomalyAllowApi(client);
    }

    public IAdminAuditAnomalyAllowApi Allow { get; }
}

internal class AdminAuditAnomalyAllowApi : IAdminAuditAnomalyAllowApi
{
    private readonly IWebApiClient _client;
    public AdminAuditAnomalyAllowApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<AllowListResponse> GetItem()
    {
        return _client.MakeUrlEncodedCall<AllowListResponse>("admin.audit.anomaly.allow.getItem");
    }

    public Task<WebApiResponse> UpdateItem(AllowListRequest request)
    {
        return _client.MakeJsonCall("admin.audit.anomaly.allow.updateItem", request);
    }
}