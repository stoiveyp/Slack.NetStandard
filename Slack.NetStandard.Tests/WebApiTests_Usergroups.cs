using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;
using Slack.NetStandard.WebApi.Usergroups;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Usergroups
    {
        [Fact]
        public async Task Usergroups_Create()
        {
            await Utility.AssertWebApi(c => c.Usergroups.Create(new UsergroupCreateRequest
            {
                Name="test group",
                IncludeCount = true
            }), "usergroups.create", "Web_UsergroupResponse.json", j =>
            {
                Assert.Equal("test group", j.Value<string>("name"));
                Assert.True(j.Value<bool>("include_count"));
            });
        }
    }
}