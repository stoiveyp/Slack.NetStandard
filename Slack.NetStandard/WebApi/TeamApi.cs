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

       public Task<TeamAccessLogResponse> AccessLogs(long before)
       {
           return AccessLogs(before, null, null);
       }

        public Task<TeamAccessLogResponse> AccessLogs(int count, int page)
        {
            return AccessLogs(null, count, page);
        }

        public Task<TeamAccessLogResponse> AccessLogs(long? before, int? count, int? page)
        {
            var dict = new Dictionary<string, string>();
            if (before.HasValue)
            {
                dict.Add(nameof(before),before.Value.ToString());
            }

            if (count.HasValue)
            {
                dict.Add(nameof(count), count.Value.ToString());
            }

            if (page.HasValue)
            {
                dict.Add(nameof(page),page.ToString());
            }

            return _client.MakeUrlEncodedCall<TeamAccessLogResponse>("team.accessLogs", dict);
        }

        public Task<BillableInfoResponse> BillableInfo(string user = null)
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(user))
            {
                dict.Add(nameof(user),user);
            }

            return _client.MakeUrlEncodedCall<BillableInfoResponse>("team.billableInfo", dict);
        }

        public Task<InfoResponse> Info(string team = null)
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(team))
            {
                dict.Add(nameof(team), team);
            }

            return _client.MakeUrlEncodedCall<InfoResponse>("team.info", dict);
        }

        public Task<TeamIntegrationLogResponse> IntegrationLogs(IntegrationLogRequest request)
        {
            return _client.MakeUrlEncodedCall<TeamIntegrationLogResponse>("team.integrationLogs", request);
        }

        public Task<TeamProfileResponse> GetProfile(string visibility = null)
        {
            var dict = new Dictionary<string,string>();
            if (!string.IsNullOrWhiteSpace(visibility))
            {
                dict.Add("visibility",visibility);
            }

            return _client.MakeUrlEncodedCall<TeamProfileResponse>("team.profile.get", dict);
        }

        public ITeamBillingApi Billing { get; }
    }
}