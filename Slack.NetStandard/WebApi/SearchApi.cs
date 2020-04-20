using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Search;

namespace Slack.NetStandard.WebApi
{
    internal class SearchApi : ISearchApi
    {
        private readonly IWebApiClient _client;

        public SearchApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<SearchResponse> All(SearchRequest request)
        {
            return _client.MakeUrlEncodedCall<SearchResponse>("search.all", request);
        }
    }
}