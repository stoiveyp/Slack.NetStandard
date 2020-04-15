using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminTeamSettingsApi
    {
        Task Info();
        Task SetDefaultChannels();
        Task SetDescription();
        Task SetDiscoverability();
        Task SetIcon();
        Task SetName();
    }
}