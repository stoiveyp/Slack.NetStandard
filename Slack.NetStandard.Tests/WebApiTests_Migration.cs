using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_Migration
{
    [Fact]
    public async Task Migration_Exchange()
    {
        await Utility.AssertEncodedWebApi(c => c.Migration.Exchange(new[] { "W123", "W456" }, true, "T12345"),
            "migration.exchange", "Web_FilesInfo.json", nvc =>
            {
                Assert.Equal("W123,W456", nvc["users"]);
                Assert.Equal("true", nvc["to_old"]);
                Assert.Equal("T12345", nvc["team_id"]);
            });
    }
}