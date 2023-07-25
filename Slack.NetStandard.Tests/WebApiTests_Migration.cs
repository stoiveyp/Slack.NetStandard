using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_Migration
{
    [Fact]
    public async Task Migration_Exchange()
    {
        await Utility.AssertEncodedWebApi(c => c.Migration.Exchange(new []{"W123", "W456"},true), "migration.exchange",
            "Web_FilesInfo.json", nvc =>
            {
                Assert.Equal("W123,W456", nvc["users"]);
                Assert.Equal("true", nvc["to_old"]);
            });
    }
}