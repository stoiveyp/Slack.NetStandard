using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Search;

namespace Slack.NetStandard.WebApi
{
    public interface ISearchApi
    {
        Task<SearchResponse> All(SearchRequest request);
        Task<SearchResponse> Files(SearchRequest request);
        Task<SearchResponse> Messages(SearchRequest request);
    }
}