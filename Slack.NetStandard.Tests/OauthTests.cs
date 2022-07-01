using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.Auth;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class OauthTests
    {
        [Fact]
        public async Task ClientAuthCheck()
        {
            var client = new HttpClient(new ActionHandler(req =>
            {
                Assert.Equal("Bearer", req.Headers.Authorization.Scheme);
                Assert.Equal("wibble", req.Headers.Authorization.Parameter);
            }));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "wibble");
            var slackClient = new SlackWebApiClient(client);
            var response = await slackClient.Auth.Test();
        }

        [Fact]
        public async Task ClientTokenCheck()
        {
            var client = new HttpClient(new ActionHandler(req =>
            {
                Assert.Equal("Bearer", req.Headers.Authorization.Scheme);
                Assert.Equal("test", req.Headers.Authorization.Parameter);
            }));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "wibble");
            var slackClient = new SlackWebApiClient(client, "test");
            var response = await slackClient.Auth.Test();
        }

        [Fact]
        public void AccessTokenInformation()
        {
            var ati = Utility.ExampleFileContent<AccessTokenInformation>("AccessTokenInformation.json");
            Assert.True(ati.OK);
            Assert.Equal("xoxb-17653672481-19874698323-pdFZKVeTuE8sk7oOcBrzbqgy",ati.AccessToken);
            Assert.NotNull(ati.AuthedUser);
            Assert.Equal("commands,incoming-webhook", ati.Scope);
            Assert.Equal("chat:write", ati.AuthedUser.Scope);
            Assert.Equal(43200, ati.ExpiresIn);
            Assert.Equal(43200, ati.AuthedUser.ExpiresIn);
        }

        [Fact]
        public async Task BasicAuthCheck()
        {
            var client = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("Basic", req.Headers.Authorization.Scheme);
                Assert.Equal("QWxhZGRpbjpPcGVuU2VzYW1l", req.Headers.Authorization.Parameter);
                Assert.Equal("code=code",await req.Content.ReadAsStringAsync());
            },Utility.ExampleFileContent("AccessTokenInformation.json")));
            var ati = await OAuthV2Builder.Exchange(client,"code", "Aladdin", "OpenSesame");
        }

        [Fact]
        public async Task ExchangeRefreshToken()
        {
            var client = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("Basic", req.Headers.Authorization.Scheme);
                Assert.Equal("QWxhZGRpbjpPcGVuU2VzYW1l", req.Headers.Authorization.Parameter);
                Assert.Equal("grant_type=refresh_token&refresh_token=reftoken", await req.Content.ReadAsStringAsync());
            }, Utility.ExampleFileContent("AccessTokenInformation.json")));
            var ati = await OAuthV2Builder.ExchangeRefreshToken(client, "reftoken", "Aladdin", "OpenSesame");
        }
    }
}
