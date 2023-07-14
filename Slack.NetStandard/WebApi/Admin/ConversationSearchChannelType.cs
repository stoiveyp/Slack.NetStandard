using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Admin;

public enum ConversationSearchChannelType
{
    [EnumMember(Value="private")]
    Private,
    [EnumMember(Value="private_exclude")]
    PrivateExclude,
    [EnumMember(Value="archived")]
    Archived,
    [EnumMember(Value="exclude_archived")]
    ExcludeArchived,
    [EnumMember(Value="private_exclude_archived")]
    PrivateExcludeArchived,
    [EnumMember(Value="multi_workspace")]
    MultiWorkspace,
    [EnumMember(Value="org_wide")]
    OrgWide,
    [EnumMember(Value="external_shared_exclude")]
    ExternalSharedExclude,
    [EnumMember(Value="external_shared")]
    ExternalShared,
    [EnumMember(Value="external_shared_private")]
    ExternalSharedPrivate,
    [EnumMember(Value="external_shared_archived")]
    ExternalSharedArchived,
    [EnumMember(Value="exclude_org_shared")]
    ExcludeOrgShared
}