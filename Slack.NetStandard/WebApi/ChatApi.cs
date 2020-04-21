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
            ScheduledMessages = new ScheduledMessageApi(client);
        }

        public IScheduledMessageApi ScheduledMessages { get; }

        public Task<PostMessageResponse> Post(PostMessageRequest request)
        {
            return _client.MakeJsonCall<PostMessageRequest, PostMessageResponse>("chat.postMessage", request);
        }

        public Task<EphemeralResponse> PostEphemeral(PostEphemeralMessageRequest request)
        {
            return _client.MakeJsonCall<PostEphemeralMessageRequest, EphemeralResponse>("chat.postEphemeral", request);
        }

        public Task<MessageResponse> Delete(string channel, Timestamp timestamp, bool? asUser = null)
        {
            return _client.MakeJsonCall<DeleteRequest, MessageResponse>("chat.delete", new DeleteRequest
            {
                Channel = channel,
                Timestamp = timestamp,
                AsUser = asUser
            });
        }

        public Task<GetPermalinkResponse> Permalink(string channel, string timestamp)
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
            return _client.MakeJsonCall("chat.unfurl", request);
        }

        public Task<UpdateMessageResponse> Update(UpdateMessageRequest request)
        {
            return _client.MakeJsonCall<UpdateMessageRequest, UpdateMessageResponse>("chat.updateMessage", request);
        }
    }
}
