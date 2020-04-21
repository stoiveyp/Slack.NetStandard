using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;

namespace Slack.NetStandard.WebApi
{
    public interface IUsergroupsApi
    {
        Task<UsergroupResponse> Create(UsergroupCreateRequest request);
    }
}