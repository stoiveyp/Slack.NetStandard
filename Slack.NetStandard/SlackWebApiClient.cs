using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    public class SlackWebApiClient:IWebApiClient, ISlackApiClient
    {
        private IConversationsApi _conversations;
        public IConversationsApi Conversations => _conversations ??= new ConversationsApi(this);


        private IChatApi _chat;
        public IChatApi Chat => _chat ??= new ChatApi(this);

        private IAdminApi _admin;
        public IAdminApi Admin => _admin ??= new AdminApi(this);

        private IViewApi _view;
        public IViewApi View => _view ??= new ViewApi(this);

        private IAppsApi _apps;
        public IAppsApi Apps => _apps ??= new AppsApi(this);

        private IAuthApi _auth;
        public IAuthApi Auth => _auth ??= new AuthApi(this);

        private IBotsApi _bots;
        public IBotsApi Bots => _bots ??= new BotsApi(this);

        private IDndApi _dnd;
        public IDndApi Dnd => _dnd ??= new DndApi(this);

        private IEmojiApi _emoji;
        public IEmojiApi Emoji => _emoji ??= new EmojiApi(this);

        private IFilesApi _files;
        public IFilesApi Files => _files ??= new FilesApi(this);

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

        public async Task<TResponse> MakeJsonCall<TRequest, TResponse>(string methodName, TRequest request) where TResponse:WebApiResponseBase
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

        public Task<TResponse> MakeUrlEncodedCall<TResponse>(string methodName, object request) where TResponse : WebApiResponseBase
        {
            var dict = JObject.FromObject(request).Properties().ToDictionary(j => j.Name, j =>
            {
                if (j.Value.Type == JTokenType.Boolean)
                {
                    return j.Value.ToString().ToLower();
                }
                return j.Value.ToString();
            });
            return MakeUrlEncodedCall<TResponse>(methodName, dict);
        }

        public Task<WebApiResponse> MakeUrlEncodedCall(string methodName, Dictionary<string, string> request)
        {
            return MakeUrlEncodedCall<WebApiResponse>(methodName, request);
        }

        public async Task<TResponse> MakeUrlEncodedCall<TResponse>(string methodName, Dictionary<string, string> request) where TResponse : WebApiResponseBase
        {
            var content = new FormUrlEncodedContent(request);
            content.Headers.ContentType.CharSet = "utf-8";
            var message = await Client.PostAsync(methodName, content);
            return DeserializeResponse<TResponse>(await message.Content.ReadAsStreamAsync());
        }

        public Task<TResponse> MakeMultiPartCall<TResponse>(string methodName, object textData, Dictionary<string,Stream> streams) where TResponse : WebApiResponseBase
        {
            var dict = JObject.FromObject(textData).Properties().ToDictionary(j => j.Name, j =>
            {
                if (j.Value.Type == JTokenType.Boolean)
                {
                    return j.Value.ToString().ToLower();
                }
                return j.Value.ToString();
            });
            return MakeMultiPartCall<TResponse>(methodName, dict, streams);
        }

        public async Task<TResponse> MakeMultiPartCall<TResponse>(string methodName,Dictionary<string,string> textData, Dictionary<string,Stream> streams) where TResponse : WebApiResponseBase
        {
            var content = new MultipartFormDataContent();
            foreach(var item in textData)
            {
                content.Add(new StringContent(item.Value,System.Text.Encoding.UTF8),item.Key);
            }

            foreach (var item in streams)
            {
                content.Add(new StreamContent(item.Value), item.Key);
            }

            var message = await Client.PostAsync(methodName, content);
            return DeserializeResponse<TResponse>(await message.Content.ReadAsStreamAsync());
        }

        private T DeserializeResponse<T>(Stream response)
        {
            using var jsonReader = new JsonTextReader(new StreamReader(response));
            return Serializer.Deserialize<T>(jsonReader);
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
