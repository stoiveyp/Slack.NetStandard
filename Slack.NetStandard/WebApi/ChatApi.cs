using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            return MakeJsonCall<PostMessageRequest, PostMessageResponse>("chat.postMessage", request);
        }

        public Task<MessageResponse> Delete(string channel, string timestamp, bool? asUser = null)
        {
            return MakeJsonCall<DeleteRequest, MessageResponse>("chat.delete", new DeleteRequest
            {
                Channel = channel,
                Timestamp = timestamp,
                AsUser = asUser
            });
        }

        public Task<WebApiResponse> DeleteScheduledMessage(string channel, string scheduledMessageId,
            bool? asUser = null)
        {
            return MakeJsonCall<DeleteScheduledMessageRequest, WebApiResponse>("chat.deleteScheduledMessage", new DeleteScheduledMessageRequest
            {
                Channel = channel,
                ScheduledMessageId = scheduledMessageId,
                AsUser = asUser
            });
        }

        public Task<GetPermalinkResponse> GetPermalink(string channel, string timestamp)
        {
            return MakeJsonCall<GetPermalinkRequest, GetPermalinkResponse>("chat.getPermalink", new GetPermalinkRequest
            {
                Channel = channel,
                Timestamp = timestamp
            });
        }

        public Task<MessageResponse> MeMessage(string channel, string text)
        {
            return MakeJsonCall<MeMessageRequest, MessageResponse>("chat.meMessage", new MeMessageRequest
            {
                Channel = channel,
                Text = text
            });
        }

        private async Task<TResponse> MakeJsonCall<TRequest, TResponse>(string url, TRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var message = await _client.Client.PostAsync(url, content);
                return DeserializeResponse<TResponse>(await message.Content.ReadAsStreamAsync());
            }
            catch (WebException ex)
            {
                var source = ExceptionDispatchInfo.Capture(ex);
                return ProcessSlackException<TResponse>(ex, source);
            }
        }

        private T DeserializeResponse<T>(Stream response)
        {
            using (var jsonReader = new JsonTextReader(new StreamReader(response)))
            {
                return _client.Serializer.Deserialize<T>(jsonReader);
            }
        }

        private T ProcessSlackException<T>(WebException webException, ExceptionDispatchInfo source)
        {
            try
            {
                return DeserializeResponse<T>(webException.Response.GetResponseStream());
            }
            catch
            {
                source.Throw();
            }

            throw new InvalidOperationException("Processing call failed");
        }
    }
}
