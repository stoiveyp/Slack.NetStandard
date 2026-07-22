using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class ExternalAuthMissingFunctionPayload
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("team_id")]
    public string TeamId { get; set; }

    [JsonProperty("function_id")]
    public string FunctionId { get; set; }

    [JsonProperty("app_id")]
    public string AppId { get; set; }
}