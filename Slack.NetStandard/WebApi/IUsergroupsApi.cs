using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;

namespace Slack.NetStandard.WebApi
{
    public interface IUsergroupsApi
    {
        Task<UsergroupResponse> Create(UsergroupCreateRequest request);
        Task<UsergroupResponse> Disable(UsergroupDisableRequest request);
        Task<UsergroupResponse> Enable(UsergroupEnableRequest request);
        Task<UsergroupResponse> Update(UsergroupUpdateRequest request);

        Task<UsergroupListResponse> List(UsergroupListRequest request);

        IUsergroupUserApi Users { get; }
    }
}