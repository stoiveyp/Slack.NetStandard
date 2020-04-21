using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Pins
    {
        [Fact]
        public async Task Pins_Add()
        {
            await Utility.AssertEncodedWebApi(c => c.Pins.Add("C123", "1234567890.123456"), "pins.add", nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
                Assert.Equal("1234567890.123456", nvc["timestamp"]);
            });
        }

        [Fact]
        public async Task Pins_Remove()
        {
            await Utility.AssertEncodedWebApi(c => c.Pins.Remove("C123", "1234567890.123456"), "pins.remove", nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
                Assert.Equal("1234567890.123456", nvc["timestamp"]);
            });
        }

        [Fact]
        public async Task Pins_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Pins.List("C123"), "pins.list", "Web_MessageItems.json", nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
            });
        }
    }
}