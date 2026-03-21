using System.Runtime.Serialization;

namespace Slack.NetStandard.Emums;
public enum TaskDisplayModeType
{
    [EnumMember(Value="timeline")]
    Timeline,
    [EnumMember(Value="plan")]
    Plan
}
