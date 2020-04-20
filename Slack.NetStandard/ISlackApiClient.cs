using System.Threading.Tasks;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    public interface ISlackApiClient
    {
        IConversationsApi Conversations { get; }
        IChatApi Chat { get; }

        IAdminApi Admin { get; }

        IViewApi View { get; }

        IAppsApi Apps { get; }

        IDndApi Dnd { get; }

        IFilesApi Files { get; }

        IEmojiApi Emoji { get; }

        IAuthApi Auth { get; }

        IBotsApi Bots { get; }

        IMigrationApi Migration { get; }

        
        Task<WebApiResponse> Test(object data);
    }
}