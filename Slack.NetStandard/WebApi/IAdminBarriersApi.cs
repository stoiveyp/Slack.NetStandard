using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public interface IAdminBarriersApi
{
    Task<BarrierResponse> Create(CreateBarrierRequest request);
    Task<BarrierResponse> Update(UpdateBarrierRequest request);
    Task<ListBarrierResponse> List(string cursor = null, int? limit = null);
    Task<WebApiResponse> Delete(string barrierId);
}