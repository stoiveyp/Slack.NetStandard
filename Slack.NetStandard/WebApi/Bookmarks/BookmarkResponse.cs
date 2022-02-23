using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Bookmarks;

public class BookmarkResponse : WebApiResponse
{
    [JsonProperty("bookmark",NullValueHandling = NullValueHandling.Ignore)]
    public Bookmark Bookmark { get; set; }
}