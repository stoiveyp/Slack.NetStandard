using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Bookmarks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Bookmarks
    {
        [Fact]
        public async Task Bookmarks_Add()
        {
            var response = await Utility.AssertWebApi(c => c.Bookmarks.Add(new AddBookmarkRequest
                ("C123456789","test title",BookmarkType.LocalFolder)), "bookmarks.add", "Web_BookmarksAddResponse.json", jo =>
            {
                Assert.Equal("C123456789", jo.Value<string>("channel_id"));
                Assert.Equal("test title", jo.Value<string>("title"));
                Assert.Equal("local_folder", jo.Value<string>("type"));
            });

            Assert.Null(response.OtherFields);
        }

        [Fact]
        public async Task Bookmarks_Remove()
        {
            await Utility.AssertEncodedWebApi(c => c.Bookmarks.Remove("B123","C123456789"), "bookmarks.remove", "Web_BookmarksAddResponse.json", nvc =>
            {
                Assert.Equal("C123456789", nvc["channel_id"]);
                Assert.Equal("B123", nvc["bookmark_id"]);
            });
        }

        [Fact]
        public async Task Bookmarks_Edit()
        {
            var response = await Utility.AssertWebApi(c => c.Bookmarks.Edit(new UpdateBookmarkRequest
                ("B123","C123456789"){Emoji = ":clap:"}), "bookmarks.edit", "Web_BookmarksAddResponse.json", jo =>
            {
                Assert.Equal("C123456789", jo.Value<string>("channel_id"));
                Assert.Equal("B123", jo.Value<string>("bookmark_id"));
                Assert.Equal(":clap:", jo.Value<string>("emoji"));
            });

            Assert.Null(response.OtherFields);
        }
    }
}