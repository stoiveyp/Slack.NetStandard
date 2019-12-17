using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests
    {
        [Fact]
        public void ClientSetup()
        {
            var client = new SlackWebApiClient("token");
            Assert.Equal("https://slack.com/api/",client.Client.BaseAddress.ToString());
            Assert.Equal("token",client.Client.DefaultRequestHeaders.Authorization.Parameter);
            Assert.Equal("Bearer",client.Client.DefaultRequestHeaders.Authorization.Scheme);
        }

        [Fact]
        public async Task Chat_PostMessage()
        {
            var http = new HttpClient(new ActionHandler(req =>
            {

            }));
            var client = new SlackWebApiClient(http);
            var response = await client.Chat.PostMessage();
        }
    }
}
