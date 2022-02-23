using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Bookmarks;

namespace Slack.NetStandard.WebApi;

public interface IBookmarksApi
{
    Task<BookmarkResponse> Add(AddBookmarkRequest request);
    Task<WebApiResponse> Remove(string bookmarkId, string channelId);
    Task<BookmarkResponse> Edit(UpdateBookmarkRequest request);
}