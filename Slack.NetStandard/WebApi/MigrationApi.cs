using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Migration;

namespace Slack.NetStandard.WebApi
{
    internal class MigrationApi : IMigrationApi
    {
        private readonly IWebApiClient _client;

        public MigrationApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<ExchangeResponse> Exchange(string[] users, bool? toOld = null, string teamId = null)
        {
            var dict = new Dictionary<string, string> { { "users", string.Join(",", users) } }
                .AddIfValue("to_old", toOld).AddIfValue("team_id", teamId);

            return _client.MakeUrlEncodedCall<ExchangeResponse>("migration.exchange", dict);
        }
    }
}