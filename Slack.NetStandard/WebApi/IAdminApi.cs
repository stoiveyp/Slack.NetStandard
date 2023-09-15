namespace Slack.NetStandard.WebApi
{
    public interface IAdminApi
    {
        IAdminAppsApi Apps { get; }
        IAdminConversationsApi Conversations { get; }
        IAdminEmojiApi Emoji { get; }

        IAdminInviteRequestsApi InviteRequests { get; }

        IAdminRolesApi Roles { get; }

        IAdminTeamsApi Teams { get; }

        IAdminUsersApi Users { get; }

        IAdminAnalyticsApi Analytics { get; }

        IAdminAuditAnomalyApi AuditAnomaly { get; }

        IAdminAuthPolicyApi AuthPolicy { get; }

        IAdminBarriersApi Barriers { get; }

        IAdminUsergroupsApi Usergroups { get; }

        IAdminWorkflowsApi Workflows { get; }

        IAdminFunctionsApi Functions { get; }
    }
}
