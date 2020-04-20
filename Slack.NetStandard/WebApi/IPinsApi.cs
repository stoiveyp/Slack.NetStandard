using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IPinsApi
    {
        Task<WebApiResponse> Add(string channel, Timestamp timestamp);
        Task<WebApiResponse> Remove(string channel, Timestamp timestamp);

        Task<MessageItemsResponse> List(string channel);
    }
}