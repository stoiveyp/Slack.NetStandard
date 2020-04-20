using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reaction;

namespace Slack.NetStandard.WebApi
{
    internal class ReactionsApi : IReactionsApi
    {
        private readonly IWebApiClient _client;

        public ReactionsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Add(string channel, Timestamp timestamp, string name)
        {
            return _client.MakeUrlEncodedCall("reactions.add", new Dictionary<string, string>
            {
                {nameof(channel), channel},
                {nameof(timestamp), timestamp},
                {nameof(name),name }
            });
        }

        public Task<ReactionGetResponse> Get(string file, bool? full = null)
        {
            var dict = new Dictionary<string, string>
            {
                {nameof(file), file},
            };

            if(full.HasValue)
            {
                dict.Add(nameof(full),full.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<ReactionGetResponse>("reactions.get", dict);
        }

        public Task<ReactionGetResponse> Get(string channel, Timestamp timestamp, bool? full = null)
        {
            var dict = new Dictionary<string, string>
            {
                {nameof(channel), channel},
                {nameof(timestamp), timestamp},
            };

            if (full.HasValue)
            {
                dict.Add(nameof(full), full.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<ReactionGetResponse>("reactions.get", dict);
        }
    }
}