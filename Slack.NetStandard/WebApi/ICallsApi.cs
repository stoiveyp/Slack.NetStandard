using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Calls;

namespace Slack.NetStandard.WebApi;

public interface ICallsApi
{
    Task<CallResponse> Start(Call request);
    Task<WebApiResponse> End(string id, int? duration = null);
    Task<CallResponse> Info(string id);
    Task<CallResponse> Update(UpdateCallRequest request);
    Task<WebApiResponse> AddParticipant(ModifyParticipantRequest request);
    Task<WebApiResponse> RemoveParticipant(ModifyParticipantRequest request);
}