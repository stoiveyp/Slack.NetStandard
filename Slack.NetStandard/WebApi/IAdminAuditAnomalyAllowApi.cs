using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public interface IAdminAuditAnomalyAllowApi
{
    public Task<AllowListResponse> GetItem();
    public Task<WebApiResponse> UpdateItem(AllowListRequest request);
}