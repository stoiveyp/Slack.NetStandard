using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Bookmarks;

namespace Slack.NetStandard.WebApi;

internal class BookmarksApi : IBookmarksApi
{
    private readonly IWebApiClient _client;

    public BookmarksApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<BookmarkResponse> Add(AddBookmarkRequest request)
    {
        return _client.MakeJsonCall<AddBookmarkRequest, BookmarkResponse>("bookmarks.add",request);
    }

    public Task<WebApiResponse> Remove(string bookmarkId, string channelId)
    {
        return _client.MakeUrlEncodedCall("bookmarks.remove", new Dictionary<string, string>()
        {
            { "bookmark_id", bookmarkId },
            { "channel_id", channelId }
        });
    }

    public Task<BookmarkResponse> Edit(UpdateBookmarkRequest request)
    {
        return _client.MakeJsonCall<UpdateBookmarkRequest, BookmarkResponse>("bookmarks.edit", request);
    }
}