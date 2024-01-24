using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reaction;

namespace Slack.NetStandard.WebApi
{
    public interface IReactionsApi
    {
        Task<WebApiResponse> Add(string channel, Timestamp timestamp, string name);
        Task<ReactionGetResponse> Get(string channel, Timestamp timestamp, bool? full = null);

        Task<ReactionListResponse> List(ReactionListRequest request);

        Task<WebApiResponse> Remove(string channel, Timestamp timestamp, string name);
    }
}