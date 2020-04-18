using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Chat;

namespace Slack.NetStandard.WebApi
{
    public interface IChatApi
    {
        Task<PostMessageResponse> Post(PostMessageRequest request);
        Task<EphemeralResponse> PostEphemeral(PostEphemeralMessageRequest request);

        IScheduledMessageApi ScheduledMessages { get; }
        Task<MessageResponse> Delete(string channel, string timestamp, bool? asUser = null);

        Task<GetPermalinkResponse> Permalink(string channel, string timestamp);

        Task<MessageResponse> MeMessage(string channel, string action);
        Task<WebApiResponse> Unfurl(UnfurlRequest request);

        Task<UpdateMessageResponse> Update(UpdateMessageRequest request);
    }
}