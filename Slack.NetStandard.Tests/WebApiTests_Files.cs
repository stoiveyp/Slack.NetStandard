using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Files
    {
        [Fact]
        public async Task Files_Delete()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.Delete("F1234567890"), "files.delete", nvc => Assert.Equal("F1234567890",nvc["file"]));
        }

        [Fact]
        public async Task Files_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.Info("F1234567890"), "files.info","Web_FilesInfo.json", nvc => Assert.Equal("F1234567890", nvc["file"]));
        }
    }
}