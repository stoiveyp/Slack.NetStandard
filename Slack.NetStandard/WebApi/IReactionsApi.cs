using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reaction;

namespace Slack.NetStandard.WebApi
{
    public interface IReactionsApi
    {
        Task<WebApiResponse> Add(string channel, Timestamp timestamp, string name);
        Task<ReactionGetResponse> Get(string channel, Timestamp timestamp, bool? full = null);

        Task<MessageItemsResponse> List(string user);
        Task<MessageItemsResponse> List(string user, string cursor);
        Task<MessageItemsResponse> List(string user, int limit);
        Task<MessageItemsResponse> List(string user, string cursor, int? limit);

        Task<WebApiResponse> Remove(string channel, Timestamp timestamp, string name);
    }
}