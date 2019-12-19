using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Chat
{
    public enum MessageParsing
    {
        [EnumMember(Value="none")]
        None,
        [EnumMember(Value="client")]
        Client,
        [EnumMember(Value="full")]
        Full
    }
}