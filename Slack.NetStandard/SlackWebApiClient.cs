using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    public class SlackWebApiClient:IWebApiClient, ISlackApiClient
    {
        public IConversationsApi Conversations { get; }
        public IChatApi Chat { get; }

        public IAdminApi Admin { get; }

        public IViewApi View { get; }

        public HttpClient Client { get; set; }
        public JsonSerializer Serializer { get; set; } = JsonSerializer.CreateDefault();

        internal SlackWebApiClient(Func<HttpClient> clientAccessor)
        {
            var client = clientAccessor();
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://slack.com/api/", UriKind.Absolute);
            }

            Client = client;
            Chat = new ChatApi(this);
            Conversations = new ConversationsApi(this);
            Admin = new AdminApi(this);
            View = new ViewApi(this);
        }

        public Task<WebApiResponse> Test(object data)
        {
            return ((IWebApiClient) this).MakeJsonCall("api.test", data);
        }

        public SlackWebApiClient(string token):this(SetupClient(token))
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(nameof(token));
            }
        }

        public SlackWebApiClient(HttpClient client):this(() => client)
        {

        }

        static Func<HttpClient> SetupClient(string token)
        {
            return () =>
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return client;
            };
        }

        public Task<WebApiResponse> MakeJsonCall<TRequest>(string methodName, TRequest request)
        {
            return MakeJsonCall<TRequest, WebApiResponse>(methodName, request);
        }

        public async Task<TResponse> MakeJsonCall<TRequest, TResponse>(string methodName, TRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json"){CharSet = "utf-8"};
                var message = await Client.PostAsync(methodName, content);
                return DeserializeResponse<TResponse>(await message.Content.ReadAsStreamAsync());
            }
            catch (WebException ex)
            {
                var source = ExceptionDispatchInfo.Capture(ex);
                return ProcessSlackException<TResponse>(ex, source);
            }
        }

        public Task<WebApiResponse> MakeUrlEncodedCall(string methodName, Dictionary<string, string> request)
        {
            return MakeUrlEncodedCall<WebApiResponse>(methodName, request);
        }

        public async Task<TResponse> MakeUrlEncodedCall<TResponse>(string methodName, Dictionary<string, string> request)
        {
            var content = new FormUrlEncodedContent(request);
            content.Headers.ContentType.CharSet = "utf-8";
            var message = await Client.PostAsync(methodName, content);
            return DeserializeResponse<TResponse>(await message.Content.ReadAsStreamAsync());
        }

        private T DeserializeResponse<T>(Stream response)
        {
            using (var jsonReader = new JsonTextReader(new StreamReader(response)))
            {
                return Serializer.Deserialize<T>(jsonReader);
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
