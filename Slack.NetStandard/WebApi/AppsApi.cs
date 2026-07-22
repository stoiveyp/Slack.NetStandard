using System.Collections.Generic;
using System.Linq;
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
            Datastore = new AppsDatastoreApi(client);
        }

        public IAppsManifestApi Manifest { get; }
        public IAppsDataStoreApi Datastore { get; }

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

        public Task<ListActivitiesResponse> ListActivities(ListActivitiesRequest request)
        {
            return _client.MakeJsonCall<ListActivitiesRequest, ListActivitiesResponse>("apps.activities.list", request);
        }

        public Task<ExternalTokenResponse> GetExternalAuth(string externalTokenId, bool? forceRefresh = null)
        {
            var nvc = new Dictionary<string, string> { { "external_token_id", externalTokenId } };
            nvc.AddIfValue("force_refresh", forceRefresh);
            return _client.MakeUrlEncodedCall<ExternalTokenResponse>("apps.auth.external.get", nvc);
        }

        public Task<WebApiResponse> DeleteExternalAuth(string appId = null, string externalTokenId = null, string providerKey = null)
        {
            var nvc = new Dictionary<string, string>();
            nvc.AddIfValue("app_id", appId);
            nvc.AddIfValue("external_token_id", externalTokenId);
            nvc.AddIfValue("provider_key", providerKey);
            return nvc.Any() ? _client.MakeUrlEncodedCall("apps.auth.external.delete", nvc) : _client.MakeUrlEncodedCall("apps.auth.external.delete");
        }
    }
}