using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Chat
{
    public enum MessageParsing
    {
        [EnumMember(Value="none")]
        None,
        [EnumMember(Value="full")]
        Full
    }
}