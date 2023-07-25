using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Admin;

public enum EntityType
{
    [EnumMember(Value="USER")]
    User
}