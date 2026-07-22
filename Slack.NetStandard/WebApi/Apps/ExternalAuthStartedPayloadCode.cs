using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Apps;

public enum ExternalAuthStartedPayloadCode
{
    [EnumMember(Value="app_not_found")]
    AppNotFound,
    [EnumMember(Value="app_not_installed")]
    AppNotInstalled,
    [EnumMember(Value="provider_not_found")]
    ProviderNotFound,
    [EnumMember(Value="external_auth_started")]
    ExternalAuthStarted
}