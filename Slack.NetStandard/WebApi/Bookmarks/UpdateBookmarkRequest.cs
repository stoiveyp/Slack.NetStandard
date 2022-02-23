using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Bookmarks;

public class UpdateBookmarkRequest
{
    public UpdateBookmarkRequest() { }

    public UpdateBookmarkRequest(string bookmarkId, string channelId)
    {
        BookmarkId = bookmarkId;
        ChannelId = channelId;
    }

    [JsonProperty("bookmark_id")]
    public string BookmarkId { get; set; }

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("emoji", NullValueHandling = NullValueHandling.Ignore)]
    public string Emoji { get; set; }

    [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
    public string Link { get; set; }
}