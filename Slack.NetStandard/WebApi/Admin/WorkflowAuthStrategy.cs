using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Admin;

public enum WorkflowAuthStrategy
{
    [EnumMember(Value="end_user_only")]
    EndUserOnly,
    [EnumMember(Value="builder_choice")]
    BuilderChoice
}