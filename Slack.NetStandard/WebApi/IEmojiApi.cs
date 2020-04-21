using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Emoji;

namespace Slack.NetStandard.WebApi
{
    public interface IEmojiApi
    {
        Task<EmojiListResponse> List();
    }
}