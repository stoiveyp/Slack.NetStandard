using System.Runtime.Serialization;

namespace Slack.NetStandard.Messages.Elements
{
    public enum ButtonStyle
    {
        [EnumMember(Value ="default")]
        Default,
        [EnumMember(Value = "primary")]
        Primary,
        [EnumMember(Value = "danger")]
        Danger
    }
}