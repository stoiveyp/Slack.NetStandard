using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public enum SlackListsSavedState
    {
        Unknown,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "archived")]
        Archived
    }
}