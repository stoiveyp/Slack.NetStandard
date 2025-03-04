using Slack.NetStandard.WebApi.Assistant;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IAssistantApi
    {
        Task<SearchContextResponse> SearchContext(SearchContextRequest request);
        IAssistantThreadApi ForThread(string channelId, Timestamp threadTimestamp);
    }
}
