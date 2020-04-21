using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Emoji;

namespace Slack.NetStandard.WebApi
{
    internal class EmojiApi:IEmojiApi
    {
        private readonly IWebApiClient _client;

        public EmojiApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<EmojiListResponse> List()
        {
            return _client.MakeUrlEncodedCall<EmojiListResponse>("emoji.list", new Dictionary<string, string>());
        }
    }
}