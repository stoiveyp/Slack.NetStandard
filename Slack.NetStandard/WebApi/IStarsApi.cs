using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Stars;

namespace Slack.NetStandard.WebApi
{
    public interface IStarsApi
    {
        Task<WebApiResponse> Add(string channel, string timestamp);
        Task<WebApiResponse> Add(string file);

        Task<WebApiResponse> Remove(string channel, string timestamp);
        Task<WebApiResponse> Remove(string file);

        Task<StarListResponse> List(string cursor);
        Task<StarListResponse> List(int limit);
        Task<StarListResponse> List(string cursor, int? limit);
    }
}