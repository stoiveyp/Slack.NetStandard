using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Users;

namespace Slack.NetStandard.WebApi
{
    public interface IUsersProfileApi
    {
        Task<UserProfileResponse> Get(string user = null, string includeLabels = null);
        Task<UserProfileResponse> Set(UserProfileSetRequest request);
    }
}