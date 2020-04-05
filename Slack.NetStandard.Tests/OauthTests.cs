using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.Auth;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class OauthTests
    {
        [Fact]
        public void AccessTokenInformation()
        {
            var ati = Utility.ExampleFileContent<AccessTokenInformation>("AccessTokenInformation.json");
            Assert.True(ati.OK);
            Assert.Equal("xoxb-17653672481-19874698323-pdFZKVeTuE8sk7oOcBrzbqgy",ati.AccessToken);
            Assert.NotNull(ati.AuthedUser);
            Assert.Equal("commands,incoming-webhook", ati.Scope);
            Assert.Equal("chat:write", ati.AuthedUser.Scope);
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
    }
}
