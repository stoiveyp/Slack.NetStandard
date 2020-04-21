using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;

namespace Slack.NetStandard.WebApi
{
    internal class UsergroupsApi : IUsergroupsApi
    {
        private readonly IWebApiClient _client;

        public UsergroupsApi(IWebApiClient client)
        {
            _client = client;
            Users = new UsergroupsUserApi(client);
        }

        public IUsergroupUserApi Users { get; }

        public Task<UsergroupResponse> Create(UsergroupCreateRequest request)
        {
            return _client.MakeJsonCall<UsergroupCreateRequest, UsergroupResponse>("usergroups.create", request);
        }

        public Task<UsergroupResponse> Disable(string usergroup, bool? includeCount = null)
        {
            var dict = new Dictionary<string, string>
            {
                {nameof(usergroup), usergroup}
            };

            if (includeCount.HasValue)
            {
                dict.Add("include_count",includeCount.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<UsergroupResponse>("usergroups.disable", dict);
        }

        public Task<UsergroupResponse> Enable(string usergroup, bool? includeCount = null)
        {
            var dict = new Dictionary<string, string>
            {
                {nameof(usergroup), usergroup}
            };

            if (includeCount.HasValue)
            {
                dict.Add("include_count", includeCount.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<UsergroupResponse>("usergroups.enable", dict);
        }

        public Task<UsergroupResponse> Update(UsergroupUpdateRequest request)
        {
            return _client.MakeJsonCall<UsergroupUpdateRequest, UsergroupResponse>("usergroups.update", request);
        }

        public Task<UsergroupListResponse> List(bool? includeCount = null, bool? includeDisabled = null, bool? includeUsers = null)
        {
            var dict = new Dictionary<string, string>();

            if (includeCount.HasValue)
            {
                dict.Add("include_count", includeCount.Value.ToString().ToLower());
            }

            if (includeDisabled.HasValue)
            {
                dict.Add("include_disabled", includeDisabled.Value.ToString().ToLower());
            }

            if (includeUsers.HasValue)
            {
                dict.Add("include_users", includeUsers.Value.ToString().ToLower());
            }

            return _client.MakeUrlEncodedCall<UsergroupListResponse>("usergroups.list", dict);
        }
    }

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