using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Pins;

namespace Slack.NetStandard.WebApi
{
    public interface IPinsApi
    {
        Task<WebApiResponse> Add(string channel, Timestamp timestamp);
        Task<WebApiResponse> Remove(string channel, Timestamp timestamp);

        Task<PinsListResponse> List(string channel);
    }
}