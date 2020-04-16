using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminTeamSettingsApi
    {
        Task<TeamInfoResponse> Info(string teamId);
        Task SetDefaultChannels();
        Task SetDescription();
        Task SetDiscoverability();
        Task SetIcon();
        Task SetName();
    }
}