using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminConversationsApi
    {
        Task<WebApiResponse> SetTeams(SetTeamsRequest request);
    }
}