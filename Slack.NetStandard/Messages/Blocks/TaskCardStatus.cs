using System.Runtime.Serialization;

namespace Slack.NetStandard.Messages.Blocks
{
    public enum TaskCardStatus
    {
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "complete")]
        Complete,
        [EnumMember(Value = "error")]
        Error
    }
}