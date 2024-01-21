using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;

namespace Slack.NetStandard.WebApi
{
    public interface IUsergroupUserApi
    {
        Task<UsergroupUserListResponse> List(string usergroup, bool? includeDisabled = null, string teamId = null);

        Task<UsergroupResponse> Update(string usergroup, string[] users, bool? includeCount = null,
            string teamId = null);
    }
}