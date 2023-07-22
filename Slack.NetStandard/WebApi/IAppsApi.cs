using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Apps;

namespace Slack.NetStandard.WebApi
{
    public interface IAppsApi
    {
        IAppsManifestApi Manifest { get; }
        IAppsDataStoreApi Datastore { get; }

        Task<WebApiResponse> Uninstall(string clientId, string clientSecret);
        Task<ListAuthorizationsResponse> ListAuthorizations(string context, string cursor);

        Task<ListAuthorizationsResponse> ListAuthorizations(string context, int limit);

        Task<ListAuthorizationsResponse> ListAuthorizations(string context, string cursor, int? limit);

        Task<OpenConnectionResponse> OpenConnection();

        Task<ListActivitiesResponse> ListActivities(ListActivitiesRequest request);

        Task<ExternalTokenResponse> GetExternalAuth(string externalTokenId, bool? forceRefresh = null);
        Task<WebApiResponse> DeleteExternalAuth(string appId = null, string externalTokenId = null, string providerKey = null);
    }
}
