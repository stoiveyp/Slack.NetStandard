using Slack.NetStandard.WebApi.Assistant;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public class AssistantApi : IAssistantApi
    {
        private readonly IWebApiClient _client;

        public AssistantApi(IWebApiClient client)
        {
            _client = client;
        }

        public IAssistantThreadApi ForThread(string channelId, Timestamp threadTimestamp)
        {
            return new AssistantThreadApi(_client, channelId, threadTimestamp);
        }

        public Task<SearchContextResponse> SearchContext(SearchContextRequest request)
        {
            return _client.MakeJsonCall<SearchContextRequest, SearchContextResponse>("assistant.search.context", request);
        }
    }
}
