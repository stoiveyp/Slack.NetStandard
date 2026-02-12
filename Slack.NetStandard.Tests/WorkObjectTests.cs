using Slack.NetStandard.Objects.WorkObjects;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WorkObjectTests
    {
        [Fact]
        public async Task TaskEntity()
        {
            Utility.AssertType<MetadataEntity>("WorkObjects_Task.json");
        }
    }
}
