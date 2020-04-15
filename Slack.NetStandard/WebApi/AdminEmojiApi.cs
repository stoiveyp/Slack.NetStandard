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
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> AddAlias(string name, string aliasFor)
        {
            throw new System.NotImplementedException();
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
            return _client.MakeJsonCall<EmojiListRequest,EmojiListResponse>("admin.emoji.list",
                new EmojiListRequest {Cursor = cursor, Limit = limit});
            ;
        }

        public Task<WebApiResponse> Remove(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> Rename(string name, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}