using System.Threading.Tasks;

namespace Slack.NetStandard
{
    internal interface IWebApiClient
    {
        Task<TResponse> MakeJsonCall<TRequest, TResponse>(string url, TRequest request);
    }
}
