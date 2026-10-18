using Slack.NetStandard.WebApi.Assistant;
using System;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    [Obsolete("This API is being deprecated in February 2027. Please refer to https://docs.slack.dev/ai/migrating-to-agent-messaging/ for more information on migrating to agent messaging", false)]
    public interface IAssistantApi
    {
        Task<SearchContextResponse> SearchContext(SearchContextRequest request);
        Task<SearchInfoResponse> SearchInfo();
        IAssistantThreadApi ForThread(string channelId, Timestamp threadTimestamp);
    }
}
