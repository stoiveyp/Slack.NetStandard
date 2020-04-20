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
                Highlight=true
            };
            await Utility.AssertEncodedWebApi(c => c.Search.All(searchRequest), "search.all", "Web_SearchAll.json", nvc =>
            {
                Assert.Equal("pickleface",nvc["query"]);
                Assert.Equal("true",nvc["highlight"]);
            });
        }
    }
}