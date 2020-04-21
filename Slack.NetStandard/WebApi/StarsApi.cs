using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Stars;

namespace Slack.NetStandard.WebApi
{
    internal class StarsApi : IStarsApi
    {
        private readonly IWebApiClient _client;

        public StarsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Add(string channel, string timestamp)
        {
            return _client.MakeUrlEncodedCall("stars.add", new Dictionary<string, string>
            {
                {nameof(channel), channel},
                {nameof(timestamp), timestamp}
            });
        }

        public Task<WebApiResponse> Add(string file)
        {
            return _client.MakeUrlEncodedCall("stars.add", new Dictionary<string, string>
            {
                {nameof(file), file}
            });
        }

        public Task<WebApiResponse> Remove(string channel, string timestamp)
        {
            return _client.MakeUrlEncodedCall("stars.remove", new Dictionary<string, string>
            {
                {nameof(channel), channel},
                {nameof(timestamp), timestamp}
            });
        }

        public Task<WebApiResponse> Remove(string file)
        {
            return _client.MakeUrlEncodedCall("stars.remove", new Dictionary<string, string>
            {
                {nameof(file), file}
            });
        }

        public Task<StarListResponse> List(string cursor)
        {
            return List(cursor, null);
        }

        public Task<StarListResponse> List(int limit)
        {
            return List(null, limit);
        }

        public Task<StarListResponse> List(string cursor, int? limit)
        {
            return _client.MakeJsonCall<CursorLimit, StarListResponse>("stars.list",new CursorLimit
            {
                Cursor=cursor,
                Limit=limit
            });
        }
    }
}