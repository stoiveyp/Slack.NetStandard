using System;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Apps;

namespace Slack.NetStandard.WebApi
{
    public interface IAppsApi
    {
        Task<WebApiResponse> Uninstall(string clientId, string clientSecret);
        Task<ListAuthorizationsResponse> ListAuthorizations(string context, string cursor);

        Task<ListAuthorizationsResponse> ListAuthorizations(string context, int limit);

        Task<ListAuthorizationsResponse> ListAuthorizations(string context, string cursor, int? limit);

        Task<OpenConnectionResponse> OpenConnection();
    }
}
