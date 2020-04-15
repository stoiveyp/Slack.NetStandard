using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminTeamsApi
    {
        Task List();
        Task ListAdmins();
        Task ListOwners();
        Task Create();

        IAdminTeamSettingsApi Settings { get; }
    }
}