using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Calls;

namespace Slack.NetStandard.WebApi;

internal class CallsApi : ICallsApi
{
    private readonly IWebApiClient _client;

    public CallsApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<CallResponse> Start(Call request)
    {
        return _client.MakeJsonCall<Call, CallResponse>("calls.add", request);
    }

    public Task<WebApiResponse> End(string id, int? duration = null)
    {
        var jo = new JObject(new JProperty("id", id));
        jo.AddIfValue("duration", duration);
        return _client.MakeJsonCall("calls.end", jo);
    }

    public Task<CallResponse> Info(string id)
    {
        var jo = new JObject(new JProperty("id", id));
        return _client.MakeJsonCall<JObject, CallResponse>("calls.info", jo);
    }

    public Task<CallResponse> Update(UpdateCallRequest request)
    {
        return _client.MakeJsonCall<UpdateCallRequest, CallResponse>("calls.update", request);
    }

    public Task<WebApiResponse> AddParticipant(ModifyParticipantRequest request)
    {
        return _client.MakeJsonCall("calls.participants.add", request);
    }

    public Task<WebApiResponse> RemoveParticipant(ModifyParticipantRequest request)
    {
        return _client.MakeJsonCall("calls.participants.remove", request);
    }
}