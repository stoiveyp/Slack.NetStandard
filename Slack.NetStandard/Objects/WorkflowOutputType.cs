using System.Runtime.Serialization;

namespace Slack.NetStandard.Objects
{
    public enum WorkflowOutputType
    {
        [EnumMember(Value="text")]
        Text,
        [EnumMember(Value = "channel")]
        Channel,
        [EnumMember(Value = "user")]
        User
    }
}