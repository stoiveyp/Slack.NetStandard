using Slack.NetStandard.WebApi;
using System.Net.Http;
using Xunit;
using System.Threading.Tasks;
using System;

namespace Slack.NetStandard.Tests
{
    public class RetryTests
    {
        [Fact]
        public async Task RetryShortCircuitsOnSuccessfulResponse()
        {
            var response = new WebApiResponse();
            response.OK = true;

            var http = new HttpClient(new ActionHandler(req => Task.FromResult(response)));
            var client = new SlackWebApiClient(http);
            var called = 0;

            await client.RateLimited(c => { called++; return Task.FromResult(response); }, 1);
            Assert.Equal(1, called);
        }

        [Fact]
        public async Task RetryShortCircuitsOnFailedResponseWithoutRetry()
        {
            var response = new WebApiResponse();
            response.OK = false;

            var http = new HttpClient(new ActionHandler(req => Task.FromResult(response)));
            var client = new SlackWebApiClient(http);
            var called = 0;

            await client.RateLimited(c => { called++; return Task.FromResult(response); }, 1);
            Assert.Equal(1, called);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        [InlineData(5, 6)]
        public async Task RetryReturnsFailedResponseAfterMaxAttempts(int retries, int expected)
        {
            var response = new WebApiResponse();
            response.OK = false;
            response.RetryAfter = TimeSpan.FromSeconds(1);

            var http = new HttpClient(new ActionHandler(req => Task.CompletedTask));
            var client = new SlackWebApiClient(http);
            var called = 0;

            await TakesAtLeast(client.RateLimited(c => { called++; return Task.FromResult(response); }, retries),TimeSpan.FromSeconds(retries));
            Assert.Equal(expected, called);
        }

        private async Task TakesAtLeast(Task method, TimeSpan minDuration)
        {
            var delay = Task.Delay(minDuration);
            var result = await Task.WhenAny(method, delay);
            if(result == method)
            {
                throw new InvalidOperationException("Method completed before minimum duration");
            }
            await method;
        }



    }
}
