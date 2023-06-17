using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi;

public interface IAdminBarriersApi
{
    Task<CreateBarrierResponse> Create(CreateBarrierRequest request);
}