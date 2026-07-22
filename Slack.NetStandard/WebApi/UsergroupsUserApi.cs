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

        public Task<UsergroupUserListResponse> List(string usergroup, bool? includeDisabled = null,
            string teamId = null)
        {
            var dict = new Dictionary<string, string>().AddIfValue("usergroup", usergroup)
                .AddIfValue("include_disabled", includeDisabled).AddIfValue("team_id", teamId);

            return _client.MakeUrlEncodedCall<UsergroupUserListResponse>("usergroups.users.list", dict);
        }

        public Task<UsergroupResponse> Update(string usergroup, string[] users, bool? includeCount = null,
            string teamId = null)
        {
            var dict = new Dictionary<string, string>().AddIfValue("usergroup", usergroup)
                .AddIfValue("users", string.Join(",", users)).AddIfValue("include_count", includeCount)
                .AddIfValue("team_id", teamId);
                
            return _client.MakeUrlEncodedCall<UsergroupResponse>("usergroups.users.update", dict);
        }
    }
}