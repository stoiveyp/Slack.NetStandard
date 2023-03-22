using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reaction;

namespace Slack.NetStandard.WebApi
{
    public interface IReactionsApi
    {
        Task<WebApiResponse> Add(string channel, Timestamp timestamp, string name);
        Task<ReactionGetResponse> Get(string channel, Timestamp timestamp, bool? full = null);

        Task<ReactionListResponse> List(string user);
        Task<ReactionListResponse> List(string user, string cursor);
        Task<ReactionListResponse> List(string user, int limit);
        Task<ReactionListResponse> List(string user, string cursor, int? limit);

        Task<WebApiResponse> Remove(string channel, Timestamp timestamp, string name);
    }
}