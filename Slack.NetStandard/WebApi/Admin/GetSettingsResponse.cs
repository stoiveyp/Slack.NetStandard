using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class GetSettingsResponse : WebApiResponse
{
    [JsonProperty("session_settings",NullValueHandling = NullValueHandling.Ignore)]
    public UserSessionSettings[] SessionSettings { get; set; }

    [JsonProperty("no_settings_applied",NullValueHandling = NullValueHandling.Ignore)]
    public string[] NoSettingsApplied { get; set; }
}