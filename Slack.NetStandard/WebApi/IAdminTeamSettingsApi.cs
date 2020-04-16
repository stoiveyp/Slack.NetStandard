using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminTeamSettingsApi
    {
        Task<TeamInfoResponse> Info(string teamId);
        Task<WebApiResponse> SetDefaultChannels(string teamId, params string[] channelIds);
        Task<WebApiResponse> SetDescription(string teamId, string description);
        Task SetDiscoverability();
        Task SetIcon();
        Task SetName();
    }
}