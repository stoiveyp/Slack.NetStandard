using System.Runtime.Serialization;

namespace Slack.NetStandard.Interaction
{
    public enum InteractionType
    {
        [EnumMember(Value="block_actions")]
        BlockActions,
        [EnumMember(Value="interactive_message")]
        InteractiveMessage
    }
}