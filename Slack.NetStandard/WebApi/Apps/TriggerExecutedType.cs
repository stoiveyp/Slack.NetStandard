using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Apps;

public enum TriggerExecutedType
{
    [EnumMember(Value="event")]
    Event,
    [EnumMember(Value="shortcut")]
    Shortcut,
    [EnumMember(Value="webhook")]
    Webhook,
    [EnumMember(Value="external")]
    External,
    [EnumMember(Value="scheduled")]
    Scheduled,
    [EnumMember(Value="blockkit")]
    BlockKit
}