using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Admin
{
    public enum TeamDiscoverability
    {
        [EnumMember(Value="open")]
        Open,
        [EnumMember(Value="closed")]
        Closed,
        [EnumMember(Value="invite_only")]
        InviteOnly,
        [EnumMember(Value="unlisted")]
        Unlisted,
        [EnumMember(Value="hidden")]
        Hidden
    }
}