using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Bookmarks;

public class AddBookmarkRequest
{
    public AddBookmarkRequest(){}

    public AddBookmarkRequest(string channelId, string title, BookmarkType type)
    {
        ChannelId = channelId;
        Title = title;
        Type = type;
    }

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public BookmarkType Type { get; set; }

    [JsonProperty("emoji",NullValueHandling = NullValueHandling.Ignore)]
    public string Emoji { get; set; }

    [JsonProperty("entity_id",NullValueHandling = NullValueHandling.Ignore)]
    public string EntityId { get; set; }

    [JsonProperty("link",NullValueHandling = NullValueHandling.Ignore)]
    public string Link { get; set; }

    [JsonProperty("parent_id",NullValueHandling = NullValueHandling.Ignore)]
    public string ParentId { get; set; }
}