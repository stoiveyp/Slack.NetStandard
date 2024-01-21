using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reaction;

namespace Slack.NetStandard.WebApi
{
    public interface IReactionsApi
    {
        Task<WebApiResponse> Add(string channel, Timestamp timestamp, string name);
        Task<ReactionGetResponse> Get(string channel, Timestamp timestamp, bool? full = null);
        
        Task<ReactionListResponse> List(string user, string cursor = null, int? limit = null, string teamId = null);

        Task<WebApiResponse> Remove(string channel, Timestamp timestamp, string name);
    }
}