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

        IPinsApi Pins { get; }

        IReactionsApi Reactions { get; }

        IRemindersApi Reminders { get; }

        ISearchApi Search { get; }

        IStarsApi Stars { get; }

        ITeamApi Team { get; }

        IUsergroupsApi Usergroups { get; }

        IUsersApi Users { get; }

        IWorkflowApi Workflow { get; }

        IBookmarksApi Bookmarks { get; }

        ICallsApi Calls { get; }

        IFunctionsApi Functions { get; }

        ICanvasesApi Canvases { get; }

        Task<WebApiResponse> Test(object data);
    }
}