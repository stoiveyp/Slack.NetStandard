using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Apps;

namespace Slack.NetStandard.WebApi
{
    internal class AppsApi : IAppsApi
    {
        private readonly IWebApiClient _client;

        public AppsApi(IWebApiClient client)
        {
            _client = client;
            Manifest = new AppsManifestApi(client);
        }

        public IAppsManifestApi Manifest { get; }

        public Task<WebApiResponse> Uninstall(string clientId, string clientSecret)
        {
            return _client.MakeUrlEncodedCall("apps.uninstall", new Dictionary<string, string>
            {
                {"client_id", clientId},
                {"client_secret", clientSecret}
            });
        }

        public Task<ListAuthorizationsResponse> ListAuthorizations(string context, string cursor)
        {
            return ListAuthorizations(context, cursor, null);
        }

        public Task<ListAuthorizationsResponse> ListAuthorizations(string context, int limit)
        {
            return ListAuthorizations(context, null, limit);
        }

        public Task<ListAuthorizationsResponse> ListAuthorizations(string context, string cursor, int? limit)
        {
            var dict = new Dictionary<string, string>
            {
                {"event_context",context}
            };
            if (!string.IsNullOrWhiteSpace(cursor))
            {
                dict.Add("cursor", cursor);
            }

            if (limit.HasValue)
            {
                dict.Add("limit", limit.Value.ToString());
            }

            return _client.MakeUrlEncodedCall<ListAuthorizationsResponse>("apps.event.authorizations.list", dict);
        }

        public Task<OpenConnectionResponse> OpenConnection()
        {
            return _client.MakeUrlEncodedCall<OpenConnectionResponse>("apps.connections.open");
        }
    }
}