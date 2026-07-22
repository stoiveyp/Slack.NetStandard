using Newtonsoft.Json;
using Slack.NetStandard.Objects.WorkObjects;

namespace Slack.NetStandard.EventsApi.CallbackEvents;

public class EntityDetailsRequested : CallbackEvent
{
    public const string EventType = "entity_details_requested";

    [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
    public string User { get; set; }

    [JsonProperty("external_ref", NullValueHandling = NullValueHandling.Ignore)]
    public ExternalRef ExternalReference { get; set; }

    [JsonProperty("entity_url", NullValueHandling = NullValueHandling.Ignore)]
    public string EntityUrl { get; set; }

    [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
    public Link Link { get; set; }

    [JsonProperty("app_unfurl_url", NullValueHandling = NullValueHandling.Ignore)]
    public string AppUnfurlUrl { get; set; }

    [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)] 
    public string Channel { get; set; }

    [JsonProperty("message_ts", NullValueHandling = NullValueHandling.Ignore)] 
    public string MessageTimestamp { get; set; }

    [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)] 
    public string ThreadTimestamp { get; set; }

    [JsonProperty("user_locale", NullValueHandling = NullValueHandling.Ignore)] 
    public string UserLocale { get; set; }

    [JsonProperty("trigger_id", NullValueHandling = NullValueHandling.Ignore)] 
    public string TriggerId { get; set; }
}
