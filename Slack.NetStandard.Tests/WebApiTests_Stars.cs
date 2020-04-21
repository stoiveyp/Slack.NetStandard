using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Stars
    {
        [Fact]
        public async Task Stars_Add()
        {
            await Utility.AssertEncodedWebApi(c => c.Stars.Add("C123","12345.6789"), "stars.add",  nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
                Assert.Equal("12345.6789", nvc["timestamp"]);
            });

            await Utility.AssertEncodedWebApi(c => c.Stars.Add("F1234"), "stars.add", nvc =>
            {
                Assert.Equal("F1234", nvc["file"]);
            });
        }

        [Fact]
        public async Task Stars_Remove()
        {
            await Utility.AssertEncodedWebApi(c => c.Stars.Remove("C123", "12345.6789"), "stars.remove", nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
                Assert.Equal("12345.6789", nvc["timestamp"]);
            });

            await Utility.AssertEncodedWebApi(c => c.Stars.Remove("F1234"), "stars.remove", nvc =>
            {
                Assert.Equal("F1234", nvc["file"]);
            });
        }

        [Fact]
        public async Task Stars_List()
        {
            await Utility.AssertWebApi(c => c.Stars.List("BBBB",10), "stars.list","Web_StarsList.json", j =>
            {
                Assert.Equal("BBBB", j.Value<string>("cursor"));
                Assert.Equal(10, j.Value<int>("limit"));
            });
        }
    }
}