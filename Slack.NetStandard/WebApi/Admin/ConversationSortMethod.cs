using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Admin;

public enum ConversationSortMethod
{
    [EnumMember(Value="relevant")]
    Relevant,
    [EnumMember(Value="name")]
    Name,
    [EnumMember(Value="member_count")]
    MemberCount,
    [EnumMember(Value="created")]
    Created
}