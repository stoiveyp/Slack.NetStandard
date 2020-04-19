using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    internal interface IWebApiClient
    {
        Task<WebApiResponse> MakeJsonCall<TRequest>(string methodName, TRequest request);
        Task<TResponse> MakeJsonCall<TRequest, TResponse>(string methodName, TRequest request) where TResponse : WebApiResponseBase;
        Task<WebApiResponse> MakeUrlEncodedCall(string methodName, Dictionary<string, string> dictionary);
        Task<T> MakeUrlEncodedCall<T>(string methodName, Dictionary<string, string> dictionary) where T:WebApiResponseBase;
        Task<T> MakeUrlEncodedCall<T>(string methodName, object dictionary) where T : WebApiResponseBase;

        Task<TResponse> MakeMultiPartCall<TResponse>(string methodName, Dictionary<string, string> textData,
            Stream stream) where TResponse : WebApiResponseBase;

        Task<TResponse> MakeMultiPartCall<TResponse>(string methodName, object textData, Stream stream)
            where TResponse : WebApiResponseBase;
    }
}
