using System.Threading;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;

namespace Slack.NetStandard.WebApi
{
    public interface IUsergroupsApi
    {
        Task<UsergroupResponse> Create(UsergroupCreateRequest request);
        Task<UsergroupResponse> Disable(string usergroup, bool? includeCount = null);
        Task<UsergroupResponse> Enable(string usergroup, bool? includeCount = null);

        Task<UsergroupResponse> Update(UsergroupUpdateRequest request);

        Task<UsergroupListResponse> List(bool? includeCount = null, bool? includeDisabled = null,
            bool? includeUsers = null);

        IUsergroupUserApi Users { get; }
    }
}