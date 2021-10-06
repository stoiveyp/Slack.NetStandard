using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    public interface ITeamBillingApi
    {
        Task<BillingInfoResponse> Info();
    }
}