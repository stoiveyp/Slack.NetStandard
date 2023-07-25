using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Auth;

namespace Slack.NetStandard.WebApi
{
    public interface IAuthApi
    {
        Task<RevokedResponse> Revoke(bool? test = null);

        Task<TestResponse> Test();

        Task<TeamsListResponse> TeamsList(bool? includeIcon = null, string cursor = null, int? limit = null);
    }
}