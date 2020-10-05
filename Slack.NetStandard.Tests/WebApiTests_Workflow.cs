using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Objects;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Workflow
    {
        [Fact]
        public async Task StepCompleted()
        {
            var response = await Utility.AssertWebApi(
                c => c.Workflow.StepCompleted("xxxx",new Dictionary<string,string>{{"testkey","testvalue"}}),
                "workflows.stepCompleted",
                jobject =>
                {
                    Assert.Equal("xxxx",jobject.Value<string>("workflow_step_execute_id"));
                    Assert.Single(jobject["outputs"]);
                });
        }
    }
}