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
        [EnumMember(Value = "workflow_step_edit")]
        WorkflowStepEdit
    }
}