using Slack.NetStandard.WebApi;
using System;
using System.Threading.Tasks;

namespace Slack.NetStandard
{
    public static class RetryExtension
    {
        public static async Task<T> RateLimited<T>(this ISlackApiClient api, Func<ISlackApiClient, Task<T>> action, int maxRetries = 3) where T:WebApiResponseBase
        {
            static bool ShouldReturn(WebApiResponseBase response) => response.OK || !response.RetryAfter.HasValue;

            if(maxRetries == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxRetries), "maxRetries must be greater than 0");
            }

            var retries = 0;
            var lastResponse = await action(api);

            if(ShouldReturn(lastResponse))
            {
                return lastResponse;
            }

            while (retries < maxRetries)
            {
                await Task.Delay(lastResponse.RetryAfter.Value);

                retries++;
                var response = await action(api);
                if (ShouldReturn(response))
                {
                    return response;
                }

                lastResponse = response;
            }

            return lastResponse;
        }
    }
}
