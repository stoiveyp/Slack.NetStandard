using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    internal class TeamApi : ITeamApi
    {
        private readonly IWebApiClient _client;

        public TeamApi(IWebApiClient client)
        {
            _client = client;
            Billing = new TeamBillingApi(client);
        }

        public Task<TeamAccessLogResponse> AccessLogs(TeamAccessLogRequest request)
        {
            return _client.MakeUrlEncodedCall<TeamAccessLogResponse>("team.accessLogs", request);
        }

        public Task<BillableInfoResponse> BillableInfo(string user = null, string teamId = null)
        {
            var dict = new Dictionary<string, string>().AddIfValue("user", user).AddIfValue("team_id", teamId);
            return _client.MakeUrlEncodedCall<BillableInfoResponse>("team.billableInfo", dict);
        }

        public Task<InfoResponse> Info(string team = null, string domain = null)
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(team))
            {
                dict.Add(nameof(team), team);
            }else if (!string.IsNullOrWhiteSpace(domain))
            {
                dict.Add(nameof(domain), domain);
            }

            return _client.MakeUrlEncodedCall<InfoResponse>("team.info", dict);
        }

        public Task<TeamIntegrationLogResponse> IntegrationLogs(IntegrationLogRequest request)
        {
            return _client.MakeUrlEncodedCall<TeamIntegrationLogResponse>("team.integrationLogs", request);
        }

        public Task<TeamProfileResponse> GetProfile(string visibility = null, string teamId = null)
        {
            var dict = new Dictionary<string, string>().AddIfValue("visibility", visibility)
                .AddIfValue("team_id", teamId);
            return _client.MakeUrlEncodedCall<TeamProfileResponse>("team.profile.get", dict);
        }

        public Task<PreferenceListResponse> GetPreferences()
        {
            return _client.MakeUrlEncodedCall<PreferenceListResponse>("team.preferences.list");
        }

        public ITeamBillingApi Billing { get; }
    }
}