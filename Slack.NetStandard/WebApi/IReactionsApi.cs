using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reaction;

namespace Slack.NetStandard.WebApi
{
    public interface IReactionsApi
    {
        Task<WebApiResponse> Add(string channel, Timestamp timestamp, string name);
        Task<ReactionGetResponse> Get(string file, bool? full = null);
        Task<ReactionGetResponse> Get(string channel, Timestamp timestamp, bool? full = null);
    }
}