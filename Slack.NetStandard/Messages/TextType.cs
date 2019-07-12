using System.Runtime.Serialization;

namespace Slack.NetStandard.Messages
{
    public enum TextType
    {
        [EnumMember(Value="plain_text")]
        PlainText,
        [EnumMember(Value="mrkdwn")]
        Markdown
    }
}