using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Migration;

namespace Slack.NetStandard.WebApi
{
    internal class MigrationApi:IMigrationApi
    {
        private IWebApiClient _client;

        public MigrationApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<ExchangeResponse> Exchange(string[] users, bool? toOld = null)
        {
            var dict = new Dictionary<string, string>
            {
                {"users", string.Join(",", users)}
            };
            if(toOld.HasValue)
            {
                dict.Add("to_old",toOld.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<ExchangeResponse>("migration.exchange", dict);
        }
    }
}