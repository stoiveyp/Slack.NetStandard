using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi;

internal class AdminBarriersApi:IAdminBarriersApi
{
    private IWebApiClient _client;

    public AdminBarriersApi(IWebApiClient client)
    {
        _client = client;

    }

    public Task<CreateBarrierResponse> Create(CreateBarrierRequest request)
    {
        return _client.MakeJsonCall<CreateBarrierRequest, CreateBarrierResponse>("admin.barriers.create", request);
    }
}