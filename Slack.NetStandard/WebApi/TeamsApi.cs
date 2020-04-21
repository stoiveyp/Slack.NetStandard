using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    internal class TeamsApi : ITeamsApi
    {
        private readonly IWebApiClient _client;

        public TeamsApi(IWebApiClient client)
        {
            _client = client;
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
    }
}