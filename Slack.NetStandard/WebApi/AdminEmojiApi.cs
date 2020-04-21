using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminEmojiApi : IAdminEmojiApi
    {
        private readonly IWebApiClient _client;
        public AdminEmojiApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Add(string name, string url)
        {
            return _client.MakeUrlEncodedCall("admin.emoji.add",new Dictionary<string, string>
            {
                {"name", name},
                {"url", url}
            });
        }

        public Task<WebApiResponse> AddAlias(string name, string aliasFor)
        {
            return _client.MakeUrlEncodedCall("admin.emoji.addAlias", new Dictionary<string, string>
            {
                {"name", name},
                {"alias_for", aliasFor}
            });
        }

        public Task<EmojiListResponse> List(string cursor = null)
        {
            return List(cursor, null);
        }

        public Task<EmojiListResponse> List(int limit)
        {
            return List(null, limit);
        }

        public Task<EmojiListResponse> List(string cursor, int? limit)
        {

            var request = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(cursor))
            {
                request.Add("cursor", cursor);
            }

            if (limit.HasValue)
            {
                request.Add("limit", limit.Value.ToString());
            }

            return _client.MakeUrlEncodedCall<EmojiListResponse>("admin.emoji.list", request);
        }

        public Task<WebApiResponse> Remove(string name)
        {
            return _client.MakeUrlEncodedCall("admin.emoji.remove", new Dictionary<string, string>
            {
                {"name", name}
            });
        }

        public Task<WebApiResponse> Rename(string name, string newName)
        {
            return _client.MakeUrlEncodedCall("admin.emoji.rename", new Dictionary<string, string>
            {
                {"name", name},
                {"new_name",newName}
            });
        }
    }
}