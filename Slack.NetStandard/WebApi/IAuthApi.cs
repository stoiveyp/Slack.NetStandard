using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Auth;

namespace Slack.NetStandard.WebApi
{
    public interface IAuthApi
    {
        Task<RevokedResponse> Revoke(bool? test = null);

        Task<TestResponse> Test();
    }
}