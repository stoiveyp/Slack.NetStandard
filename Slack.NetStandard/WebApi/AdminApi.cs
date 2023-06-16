using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    internal class AdminApi:IAdminApi
    {
        public IAdminAppsApi Apps { get; }

        public IAdminConversationsApi Conversations { get; }

        public IAdminEmojiApi Emoji { get; }

        public IAdminInviteRequestsApi InviteRequests { get; }

        public IAdminTeamsApi Teams { get; }

        public IAdminUsersApi Users { get; }

        public IAdminAnalyticsApi Analytics { get; }

        public IAdminAuditAnomalyApi AuditAnomaly { get; }

        public IAdminAuthPolicyApi AuthPolicy { get; }

        internal AdminApi(IWebApiClient client)
        {
            Apps = new AdminAppsApi(client);
            Conversations = new AdminConversationsApi(client);
            Emoji = new AdminEmojiApi(client);
            InviteRequests = new AdminInviteRequestsApi(client);
            Teams = new AdminTeamsApi(client);
            Users = new AdminUsersApi(client);
            Analytics = new AdminAnalyticsApi(client);
            AuditAnomaly = new AdminAuditAnomalyApi(client);
            AuthPolicy = new AdminAuthPolicyApi(client);
        }
    }
}
