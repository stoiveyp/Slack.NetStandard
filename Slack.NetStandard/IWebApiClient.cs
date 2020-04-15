using System.Threading.Tasks;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    internal interface IWebApiClient
    {
        Task<WebApiResponse> MakeJsonCall<TRequest>(string url, TRequest request);
        Task<TResponse> MakeJsonCall<TRequest, TResponse>(string url, TRequest request);
    }
}
