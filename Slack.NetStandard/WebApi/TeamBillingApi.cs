using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    internal class TeamBillingApi : ITeamBillingApi
    {
        private readonly IWebApiClient _client;

        public TeamBillingApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<BillingInfoResponse> Info()
        {
            return _client.MakeUrlEncodedCall<BillingInfoResponse>("team.billing.info");
        }
    }
}