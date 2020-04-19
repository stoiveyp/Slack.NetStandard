using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Emoji;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Emoji
    {
        [Fact]
        public async Task Emoji_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Emoji.List(), "emoji.list","Web_EmojiList.json", Assert.Empty);
        }
    }
}