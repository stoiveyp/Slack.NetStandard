using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Apps;

public enum ExternalAuthResultPayloadCode
{
    [EnumMember(Value="oauth2_callback_error")]
    Oauth2CallbackError,
    [EnumMember(Value="oauth2_exchange_success")]
    Oauth2ExchangeSuccess
}