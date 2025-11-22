using System.Runtime.Serialization;

namespace Slack.NetStandard.Interaction
{
    public enum InteractionType
    {
        [EnumMember(Value="block_actions")]
        BlockActions,
        [EnumMember(Value="interactive_message")]
        InteractiveMessage,
        [EnumMember(Value="shortcut")]
        GlobalShortcut,
        [EnumMember(Value="message_action")]
        MessageAction,
        [EnumMember(Value="view_submission")]
        ViewSubmission,
        [EnumMember(Value="view_closed")]
        ViewClosed,
        [EnumMember(Value = "block_suggestion")]
        BlockSuggestion,
        [EnumMember(Value = "dialog_suggestion")]
        DialogSuggestion
    }
}