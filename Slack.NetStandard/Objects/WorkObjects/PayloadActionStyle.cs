using System.Runtime.Serialization;

namespace Slack.NetStandard.Objects.WorkObjects;

public enum PayloadActionStyle
{
    [EnumMember(Value = "primary")]
    Primary,
    [EnumMember(Value = "danger")]
    Danger
}