using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Apps;

public enum LogLevel
{
    [EnumMember(Value="trace")]
    Trace,
    [EnumMember(Value="debug")]
    Debug,
    [EnumMember(Value="info")]
    Info,
    [EnumMember(Value="warn")]
    Warn,
    [EnumMember(Value="error")]
    Error,
    [EnumMember(Value="fatal")]
    Fatal
}