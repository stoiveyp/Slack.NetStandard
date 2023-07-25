using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

internal class AdminBarriersApi:IAdminBarriersApi
{
    private IWebApiClient _client;

    public AdminBarriersApi(IWebApiClient client)
    {
        _client = client;

    }

    public Task<BarrierResponse> Create(CreateBarrierRequest request)
    {
        return _client.MakeJsonCall<CreateBarrierRequest, BarrierResponse>("admin.barriers.create", request);
    }

    public Task<BarrierResponse> Update(UpdateBarrierRequest request)
    {
        return _client.MakeJsonCall<CreateBarrierRequest, BarrierResponse>("admin.barriers.update", request);
    }

    public Task<ListBarrierResponse> List(string cursor = null, int? limit = null)
    {
        var dict = new Dictionary<string, string>();
        dict.AddIfValue("cursor",cursor);
        dict.AddIfValue("limit", limit);
        return _client.MakeUrlEncodedCall<ListBarrierResponse>("admin.barriers.list", dict);
    }

    public Task<WebApiResponse> Delete(string barrierId)
    {
        return _client.SingleValueEncodedCall("admin.barriers.delete", "barrier_id", barrierId);
    }
}