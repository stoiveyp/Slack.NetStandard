using System.Runtime.Serialization;

namespace Slack.NetStandard.Interaction
{
    public enum ResponseType
    {
        [EnumMember(Value = "ephemeral")]
        Ephemeral,
        [EnumMember(Value="in_channel")]
        InChannel
    }
}