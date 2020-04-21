using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;

namespace Slack.NetStandard.WebApi
{
    internal class UsergroupsUserApi : IUsergroupUserApi
    {
        private readonly IWebApiClient _client;

        public UsergroupsUserApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<UsergroupUserListResponse> List(string usergroup, bool? includeDisabled = null)
        {
            var dict = new Dictionary<string, string>{{nameof(usergroup),usergroup}};

            if (includeDisabled.HasValue)
            {
                dict.Add("include_disabled", includeDisabled.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<UsergroupUserListResponse>("usergroups.users.list", dict);
        }

        public Task<UsergroupResponse> Update(string usergroup, string[] users, bool? includeCount = null)
        {
            var dict = new Dictionary<string, string>
            {
                {nameof(usergroup), usergroup},
                {nameof(users),string.Join(",",users)}
            };

            if (includeCount.HasValue)
            {
                dict.Add("include_count", includeCount.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<UsergroupResponse>("usergroups.users.update", dict);
        }
    }
}