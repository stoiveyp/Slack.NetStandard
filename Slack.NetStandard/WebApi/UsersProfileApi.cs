using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Users;

namespace Slack.NetStandard.WebApi
{
    internal class UsersProfileApi : IUsersProfileApi
    {
        private readonly IWebApiClient _client;
        public UsersProfileApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<UserProfileResponse> Get(string user = null, string includeLabels = null)
        {
            var dict = new Dictionary<string,string>()
                .AddIfValue(nameof(user),user)
                .AddIfValue("include_labels",includeLabels);
            return _client.MakeUrlEncodedCall<UserProfileResponse>("users.profile.get", dict);
        }

        public Task<UserProfileResponse> Set(UserProfileSetRequest request)
        {
            return _client.MakeJsonCall<UserProfileSetRequest,UserProfileResponse>("users.profile.set",request);
        }
    }
}