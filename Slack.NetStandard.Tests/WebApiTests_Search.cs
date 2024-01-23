using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Search;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Search 
    {
        [Fact]
        public async Task Search_All()
        {
            var searchRequest = new SearchRequest
            {
                Query = "pickleface",
                Highlight=true,
                TeamId = "T12345"
            };
            await Utility.AssertEncodedWebApi(c => c.Search.All(searchRequest), "search.all", "Web_SearchAll.json",
                nvc =>
                {
                    Assert.Equal("pickleface", nvc["query"]);
                    Assert.Equal("true", nvc["highlight"]);
                    Assert.Equal("T12345", nvc["team_id"]);
                });
        }

        [Fact]
        public async Task Search_Files()
        {
            var searchRequest = new SearchRequest
            {
                Query = "pickleface",
                Highlight = true,
                TeamId = "T12345"
            };
            await Utility.AssertEncodedWebApi(c => c.Search.Files(searchRequest), "search.files", "Web_SearchAll.json", nvc =>
            {
                Assert.Equal("pickleface", nvc["query"]);
                Assert.Equal("true", nvc["highlight"]);
                Assert.Equal("T12345", nvc["team_id"]);
            });
        }

        [Fact]
        public async Task Search_Messages()
        {
            var searchRequest = new SearchRequest
            {
                Query = "pickleface",
                Highlight = true,
                TeamId = "T12345"
            };
            await Utility.AssertEncodedWebApi(c => c.Search.Messages(searchRequest), "search.messages", "Web_SearchAll.json", nvc =>
            {
                Assert.Equal("pickleface", nvc["query"]);
                Assert.Equal("true", nvc["highlight"]);
                Assert.Equal("T12345", nvc["team_id"]);
            });
        }
    }
}