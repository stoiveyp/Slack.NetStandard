using Slack.NetStandard.WebApi.SlackLists;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_SlackLists
    {
        [Fact]
        public async Task Create()
        {
            var request = Utility.ExampleFileContent<SlackListCreateRequest>("Web_SlackListsCreateRequest.json");
            await Utility.AssertWebApi(c => c.SlackLists.Create(request), "slackLists.create",
                "Web_SlackListsCreateResponse.json", jo =>
                {
                    Utility.CompareJson(jo, "Web_SlackListsCreateRequest.json");
                });
        }

        [Fact]
        public async Task Update()
        {
            var request = Utility.ExampleFileContent<SlackListUpdateRequest>("Web_SlackListsUpdateRequest.json");
            await Utility.AssertWebApi(c => c.SlackLists.Update(request), "slackLists.update",
                jo =>
                {
                    Utility.CompareJson(jo, "Web_SlackListsUpdateRequest.json");
                });
        }
    }
}