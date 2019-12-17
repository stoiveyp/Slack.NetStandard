using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Chat;

namespace Slack.NetStandard.WebApi
{
    internal class ChatApi:IChatApi
    {
        private readonly IWebApiClient _client;

        public ChatApi(IWebApiClient client)
        {
            _client = client;
        }

        public async Task<PostMessageResponse> PostMessage(PostMessageRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var message = await _client.Client.PostAsync("chat.postMessage",content);
                return DeserializeResponse<PostMessageResponse>(await message.Content.ReadAsStreamAsync());
            }
            catch (WebException ex)
            {
                var source = ExceptionDispatchInfo.Capture(ex);
                return ProcessSlackException<PostMessageResponse>(ex,source);
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
