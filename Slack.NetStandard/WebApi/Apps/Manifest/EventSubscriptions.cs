using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class EventSubscriptions
{
    [JsonProperty("request_url",NullValueHandling = NullValueHandling.Ignore)]
    public string RequestUrl { get; set; }

    [JsonProperty("bot_events",NullValueHandling = NullValueHandling.Ignore)]
    public string[] BotEvents { get; set; }

    [JsonProperty("user_events",NullValueHandling = NullValueHandling.Ignore)]
    public string[] User_events { get; set; }
}