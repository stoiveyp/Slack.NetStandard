using Slack.NetStandard.WebApi;
using System;
using System.Threading.Tasks;

namespace Slack.NetStandard
{
    public static class RetryExtension
    {
        public static async Task<T> RateLimited<T>(this ISlackApiClient api, Func<ISlackApiClient, Task<T>> action, int maxRetries = 3) where T:WebApiResponseBase
        {
            var retries = 0;
            var lastResponse = default(T);

            while(retries < maxRetries)
            {
                if (lastResponse != null)
                {
                    await Task.Delay(lastResponse.RetryAfter.Value);
                    retries++;
                }

                var response = await action(api);
                if (response.OK || !response.RetryAfter.HasValue)
                {
                    return response;
                }

                lastResponse = response;
            }

            return lastResponse;
        }
    }
}
