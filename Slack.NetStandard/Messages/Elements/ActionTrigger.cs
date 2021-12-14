using System.Runtime.Serialization;

namespace Slack.NetStandard.Messages.Elements
{
    public enum ActionTrigger
    {
        [EnumMember(Value = "on_enter_pressed")]
        OnEnterPressed,
        [EnumMember(Value = "on_character_entered")]
        OnCharacterEntered
    }
}