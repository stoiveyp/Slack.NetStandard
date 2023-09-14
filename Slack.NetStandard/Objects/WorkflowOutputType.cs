using System;
using System.Runtime.Serialization;

namespace Slack.NetStandard.Objects
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public enum WorkflowOutputType
    {
        [EnumMember(Value="text")]
        Text,
        [EnumMember(Value = "channel")]
        Channel,
        [EnumMember(Value = "user")]
        User
    }
}