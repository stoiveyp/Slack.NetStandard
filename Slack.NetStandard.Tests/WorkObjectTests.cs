using Slack.NetStandard.Objects.WorkObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WorkObjectTests
    {
        [Fact]
        public async Task TaskEntity()
        {
            Utility.AssertType<Dictionary<string, EntityPayloadField>>("WorkObjects_Task.json");
        }

        [Fact]
        public async Task IncidentEntity()
        {
            Utility.AssertType<Dictionary<string, EntityPayloadField>>("WorkObjects_Incident.json");
        }
    }
}
