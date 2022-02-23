using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Bookmarks;

public class BookmarkListResponse : WebApiResponse
{
    [JsonProperty("bookmarks",NullValueHandling = NullValueHandling.Ignore)]
    public Bookmark[] Bookmarks { get; set; }
}