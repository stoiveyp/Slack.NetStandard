using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Auth;

namespace Slack.NetStandard.WebApi
{
    internal class AuthApi : IAuthApi
    {
        private readonly IWebApiClient _client;

        public AuthApi(IWebApiClient client)
        {
            _client = client;
        }


        public Task<RevokedResponse> Revoke(bool? test = null)
        {
            var dict = new Dictionary<string,string>();
            if (test.HasValue)
            {
                dict.Add("test",test.ToString().ToLower());
            }
            return _client.MakeUrlEncodedCall<RevokedResponse>("auth.revoke", dict);
        }

        public Task<TestResponse> Test()
        {
            return _client.MakeUrlEncodedCall<TestResponse>("auth.test", new Dictionary<string, string>());
        }
    }
}