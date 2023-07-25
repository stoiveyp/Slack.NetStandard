using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class EventSubscriptions
{
    [JsonProperty("request_url",NullValueHandling = NullValueHandling.Ignore)]
    public string RequestUrl { get; set; }

    [JsonProperty("bot_events", NullValueHandling = NullValueHandling.Ignore)]
    public IList<string> BotEvents { get; set; } = new List<string>();

    [JsonProperty("user_events", NullValueHandling = NullValueHandling.Ignore)]
    public IList<string> UserEvents { get; set; } = new List<string>();

    public bool ShouldSerializeBotEvents() => BotEvents?.Any() ?? false;
    public bool ShouldSerializeUserEvents() => UserEvents?.Any() ?? false;
}