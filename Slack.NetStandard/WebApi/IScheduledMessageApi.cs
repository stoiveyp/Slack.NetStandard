using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Chat;

namespace Slack.NetStandard.WebApi
{
    public interface IScheduledMessageApi
    {
        Task<ScheduledMessageResponse> Post(ScheduledMessageRequest request);
        Task<WebApiResponse> Delete(string channel, string scheduledMessageId, bool? asUser = null);

        Task<ScheduledMessageListResponse> List(ScheduledMessageListRequest request);
    }
}
