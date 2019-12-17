using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    public class SlackWebApiClient:IWebApiClient
    {
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
        }
        
        public IChatApi Chat { get; }
        public HttpClient Client { get; set; }
        public JsonSerializer Serializer { get; set; } = JsonSerializer.CreateDefault();
    }
}
