using System;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Chat;

namespace Slack.NetStandard.WebApi
{
    internal class ChatApi : IChatApi
    {
        private readonly IWebApiClient _client;

        public ChatApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<PostMessageResponse> PostMessage(PostMessageRequest request)
        {
            return _client.MakeJsonCall<PostMessageRequest, PostMessageResponse>("chat.postMessage", request);
        }

        public Task<EphemeralResponse> PostEphemeral(PostMessageRequest request)
        {
            return _client.MakeJsonCall<PostMessageRequest, EphemeralResponse>("chat.postEphemeral", request);
        }

        public Task<ScheduledMessageResponse> PostScheduled(ScheduledMessageRequest request)
        {
            if (request.PostAt == 0 || request.PostAt < Epoch.Current )
            {
                throw new InvalidOperationException($"{nameof(request.PostAt)} zero or before now");
            }
            return _client.MakeJsonCall<ScheduledMessageRequest, ScheduledMessageResponse>("chat.scheduleMessage", request);
        }

        public Task<MessageResponse> Delete(string channel, string timestamp, bool? asUser = null)
        {
            return _client.MakeJsonCall<DeleteRequest, MessageResponse>("chat.delete", new DeleteRequest
            {
                Channel = channel,
                Timestamp = timestamp,
                AsUser = asUser
            });
        }

        public Task<WebApiResponse> DeleteScheduledMessage(string channel, string scheduledMessageId,
            bool? asUser = null)
        {
            return _client.MakeJsonCall<DeleteScheduledMessageRequest, WebApiResponse>("chat.deleteScheduledMessage", new DeleteScheduledMessageRequest
            {
                Channel = channel,
                ScheduledMessageId = scheduledMessageId,
                AsUser = asUser
            });
        }

        public Task<GetPermalinkResponse> GetPermalink(string channel, string timestamp)
        {
            return _client.MakeJsonCall<GetPermalinkRequest, GetPermalinkResponse>("chat.getPermalink", new GetPermalinkRequest
            {
                Channel = channel,
                Timestamp = timestamp
            });
        }

        public Task<MessageResponse> MeMessage(string channel, string text)
        {
            return _client.MakeJsonCall<MeMessageRequest, MessageResponse>("chat.meMessage", new MeMessageRequest
            {
                Channel = channel,
                Text = text
            });
        }

        public Task<WebApiResponse> Unfurl(UnfurlRequest request)
        {
            return _client.MakeJsonCall<UnfurlRequest, WebApiResponse>("chat.unfurl", request);
        }

        public Task<UpdateMessageResponse> UpdateMessage(UpdateMessageRequest request)
        {
            return _client.MakeJsonCall<UpdateMessageRequest, UpdateMessageResponse>("chat.updateMessage", request);
        }
    }
}
