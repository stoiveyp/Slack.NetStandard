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
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        public async Task RetryReturnsFailedResponseAfterMaxAttempts(int attempts, int expected)
        {
            var response = new WebApiResponse();
            response.OK = false;
            response.RetryAfter = TimeSpan.FromSeconds(1);

            var http = new HttpClient(new ActionHandler(req => Task.CompletedTask));
            var client = new SlackWebApiClient(http);
            var called = 0;

            await TakesAtLeast(client.RateLimited(c => { called++; return Task.FromResult(response); }, attempts),TimeSpan.FromSeconds(attempts));
            Assert.Equal(expected, called);
        }

        private async Task TakesAtLeast(Task method, TimeSpan minDuration)
        {
            var result = await Task.WhenAny(method, Task.Delay(minDuration));
            if(result == method)
            {
                throw new InvalidOperationException("Method completed before minimum duration");
            }
        }



    }
}
