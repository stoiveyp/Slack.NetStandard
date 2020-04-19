using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Chat;

namespace Slack.NetStandard.WebApi
{
    internal class ScheduledMessageApi:IScheduledMessageApi
    {
        private readonly IWebApiClient _client;

        public ScheduledMessageApi(IWebApiClient webApiClient)
        {
            _client = webApiClient;
        }

        public Task<ScheduledMessageResponse> Post(ScheduledMessageRequest request)
        {
            if (request.PostAt == 0 || request.PostAt < Epoch.Current)
            {
                throw new InvalidOperationException($"{nameof(request.PostAt)} zero or before now");
            }
            return _client.MakeJsonCall<ScheduledMessageRequest, ScheduledMessageResponse>("chat.scheduleMessage", request);
        }

        public Task<WebApiResponse> Delete(string channel, string scheduledMessageId,
            bool? asUser = null)
        {
            return _client.MakeJsonCall("chat.deleteScheduledMessage", new DeleteScheduledMessageRequest
            {
                Channel = channel,
                ScheduledMessageId = scheduledMessageId,
                AsUser = asUser
            });
        }

        public Task<ScheduledMessageListResponse> List(ScheduledMessageListRequest request)
        {
            return _client.MakeJsonCall<ScheduledMessageListRequest, ScheduledMessageListResponse>(
                "chat.scheduledMessages.list", request);
        }
    }
}
