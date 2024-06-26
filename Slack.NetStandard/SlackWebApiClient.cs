using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    public class SlackWebApiClient : IWebApiClient, ISlackApiClient
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

        private IMigrationApi _migration;
        public IMigrationApi Migration => _migration ??= new MigrationApi(this);

        private IPinsApi _pins;
        public IPinsApi Pins => _pins ??= new PinsApi(this);

        private IReactionsApi _reactions;
        public IReactionsApi Reactions => _reactions ??= new ReactionsApi(this);

        private IRemindersApi _reminders;
        public IRemindersApi Reminders => _reminders ??= new RemindersApi(this);

        private ISearchApi _search;
        public ISearchApi Search => _search ??= new SearchApi(this);

        private IStarsApi _stars;
        public IStarsApi Stars => _stars ??= new StarsApi(this);

        private ITeamApi _team;
        public ITeamApi Team => _team ??= new TeamApi(this);

        private IUsergroupsApi _usergroups;
        public IUsergroupsApi Usergroups => _usergroups ??= new UsergroupsApi(this);

        private IUsersApi _users;
        public IUsersApi Users => _users ??= new UsersApi(this);

        private IWorkflowApi _workflow;
        public IWorkflowApi Workflow => _workflow ??= new WorkflowApi(this);

        private IBookmarksApi _bookmarks;
        public IBookmarksApi Bookmarks => _bookmarks ??= new BookmarksApi(this);

        private ICallsApi _calls;
        public ICallsApi Calls => _calls ??= new CallsApi(this);

        private IFunctionsApi _functions;
        public IFunctionsApi Functions => _functions ??= new FunctionsApi(this);

        private ICanvasesApi _canvases;
        public ICanvasesApi Canvases => _canvases ??= new CanvasesApi(this);

        public static Uri ApiBaseAddress { get; } = new("https://slack.com/api/", UriKind.Absolute);
        public static HttpClient DefaultClient { get; } = new();
        public HttpClient Client { get; set; }
        public string Token { get; set; }

        public JsonSerializer Serializer { get; set; } = JsonSerializer.CreateDefault();

        private readonly Dictionary<string, string> _emptynvc = new();

        public Task<WebApiResponse> Test(object data)
        {
            return ((IWebApiClient)this).MakeJsonCall("api.test", data);
        }

        public SlackWebApiClient(string token) : this(null, token)
        {

        }

        public SlackWebApiClient(HttpClient client) : this(client, null)
        {

        }

        public SlackWebApiClient(HttpClient client, string token = null)
        {
            Token = token;
            Client = client ?? DefaultClient;
        }

        private static Uri MethodUrl(string methodName) => new(ApiBaseAddress, methodName);


        Task<WebApiResponse> IWebApiClient.MakeJsonCall<TRequest>(string methodName, TRequest request)
        {
            return ((IWebApiClient)this).MakeJsonCall<TRequest, WebApiResponse>(methodName, request);
        }

        async Task<TResponse> IWebApiClient.MakeJsonCall<TRequest, TResponse>(string methodName, TRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };

                var message = new HttpRequestMessage(HttpMethod.Post, MethodUrl(methodName)) { Content = content };
                HandleAuth(message);

                var response = await Client.SendAsync(message);
                return await GenerateResponseFromMessage<TResponse>(response);
            }
            catch (WebException ex)
            {
                var source = ExceptionDispatchInfo.Capture(ex);
                return ProcessSlackException<TResponse>(ex, source);
            }
        }

        private void HandleAuth(HttpRequestMessage message)
        {
            if (!string.IsNullOrWhiteSpace(Token))
            {
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
        }

        private async Task<TResponse> GenerateResponseFromMessage<TResponse>(HttpResponseMessage message) where TResponse : WebApiResponseBase
        {
            var response = DeserializeResponse<TResponse>(await message.Content.ReadAsStreamAsync());
            if ((int)message.StatusCode == 429)
            {
                response.RetryAfter = message.Headers.RetryAfter.Delta;
            }
            return response;
        }

        Task<TResponse> IWebApiClient.MakeUrlEncodedCall<TResponse>(string methodName, object request)
        {
            var dict = JObject.FromObject(request).Properties().ToDictionary(j => j.Name, j =>
            {
                if (j.Value.Type == JTokenType.Boolean)
                {
                    return j.Value.ToString().ToLower();
                }
                return j.Value.ToString();
            });
            return ((IWebApiClient)this).MakeUrlEncodedCall<TResponse>(methodName, dict);
        }

        Task<HttpResponseMessage> IWebApiClient.MakeRawUrlEncodedCall(string methodName, Dictionary<string, string> request)
        {
            var content = new FormUrlEncodedContent(request ?? _emptynvc);
            content.Headers.ContentType.CharSet = "utf-8";

            var message = new HttpRequestMessage(HttpMethod.Post, MethodUrl(methodName)) { Content = content };
            HandleAuth(message);

            return Client.SendAsync(message);
        }

        Task<WebApiResponse> IWebApiClient.MakeUrlEncodedCall(string methodName, Dictionary<string, string> request)
        {
            return ((IWebApiClient)this).MakeUrlEncodedCall<WebApiResponse>(methodName, request);
        }

        async Task<TResponse> IWebApiClient.MakeUrlEncodedCall<TResponse>(string methodName, Dictionary<string, string> request)
        {
            var content = new FormUrlEncodedContent(request ?? _emptynvc);
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Post, MethodUrl(methodName)) { Content = content };
                HandleAuth(message);
                var response = await Client.SendAsync(message);
                return await GenerateResponseFromMessage<TResponse>(response);
            }
            catch (WebException ex)
            {
                var source = ExceptionDispatchInfo.Capture(ex);
                return ProcessSlackException<TResponse>(ex, source);
            }
        }

        Task<TResponse> IWebApiClient.MakeMultiPartCall<TResponse>(string methodName, object textData, Dictionary<string, MultipartFile> streams)
        {
            var dict = JObject.FromObject(textData).Properties().ToDictionary(j => j.Name, j =>
            {
                if (j.Value.Type == JTokenType.Boolean)
                {
                    return j.Value.ToString().ToLower();
                }
                return j.Value.ToString();
            });
            return ((IWebApiClient)this).MakeMultiPartCall<TResponse>(methodName, dict, streams);
        }

        async Task<TResponse> IWebApiClient.MakeMultiPartCall<TResponse>(string methodName, Dictionary<string, string> textData, Dictionary<string, MultipartFile> streams)
        {
            var content = new MultipartFormDataContent();
            foreach (var item in textData)
            {
                content.Add(new StringContent(item.Value, System.Text.Encoding.UTF8), item.Key);
            }

            foreach (var item in streams)
            {
                content.Add(new StreamContent(item.Value.Stream), item.Key, item.Value.Filename);
            }

            try
            {
                var message = new HttpRequestMessage(HttpMethod.Post, MethodUrl(methodName)) { Content = content };
                HandleAuth(message);
                var response = await Client.SendAsync(message);
                return await GenerateResponseFromMessage<TResponse>(response);
            }
            catch (WebException ex)
            {
                var source = ExceptionDispatchInfo.Capture(ex);
                return ProcessSlackException<TResponse>(ex, source);
            }
        }

        private T DeserializeResponse<T>(Stream response)
        {
            using var jsonReader = new JsonTextReader(new StreamReader(response));
            return Serializer.Deserialize<T>(jsonReader);
        }

        private T ProcessSlackException<T>(WebException webException, ExceptionDispatchInfo source) where T : WebApiResponseBase
        {
            try
            {
                var response = DeserializeResponse<T>(webException.Response.GetResponseStream());
                if (webException.Response is HttpWebResponse webResponse)
                {
                    if ((int)webResponse.StatusCode == 429)
                    {
                        response.RetryAfter = TimeSpan.FromSeconds(double.Parse(webResponse.Headers["retry-after"]));
                    }
                }
            }
            catch
            {
                source.Throw();
            }

            throw new InvalidOperationException("Processing call failed");
        }

        string IWebApiClient.EncodeJsonForWebApi(object data)
        {
            StringBuilder sb = new StringBuilder(40);
            using (StringWriter sw = new StringWriter(sb))
            using (JsonTextWriter writer = new JsonTextWriter(sw){Formatting = Formatting.None, Indentation = 0,QuoteChar = '\''})
            {
                Serializer.Serialize(writer, data);
            }

            return sb.ToString();
        }
    }
}
