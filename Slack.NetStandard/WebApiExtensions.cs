using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard;

internal static class WebApiExtensions
{
    public static Task<WebApiResponse> SingleValueEncodedCall(this IWebApiClient client, string methodName, string name, string value)
    {
        return client.MakeUrlEncodedCall(methodName, new Dictionary<string, string> { { name, value } });
    }

    public static Task<T> SingleValueEncodedCall<T>(this IWebApiClient client, string methodName, string name, string value) where T : WebApiResponseBase
    {
        return client.MakeUrlEncodedCall<T>(methodName, new Dictionary<string, string> { { name, value } });
    }
}