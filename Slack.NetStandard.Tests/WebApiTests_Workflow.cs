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
            await Utility.AssertWebApi(
                c => c.Workflow.StepCompleted("xxxx", new Dictionary<string, object> { { "testkey", "testvalue" } }),
                "workflows.stepCompleted",
                jobject =>
                {
                    Assert.Equal("xxxx", jobject.Value<string>("workflow_step_execute_id"));
                    var value = Assert.Single(jobject["outputs"]);
                });
        }

        [Fact]
        public async Task StepFailed()
        {
            await Utility.AssertWebApi(
                c => c.Workflow.StepFailed("xxxx", "error message"),
                "workflows.stepFailed",
                jobject =>
                {
                    Assert.Equal("xxxx", jobject.Value<string>("workflow_step_execute_id"));
                    Assert.Equal("error message", jobject["error"].Value<string>("message"));
                });
        }

        [Fact]
        public async Task UpdateStep()
        {
            await Utility.AssertWebApi(
                c => c.Workflow.UpdateStep(new WorkflowStep
                {
                    WorkflowStepEditId = "xxxx",
                    Inputs = new Dictionary<string, WorkflowInput>
                    {
                        {"title",new WorkflowInput{Value="The Title", SkipVariableReplacement = false}},
                        {"submitter",new WorkflowInput{Value="{{user}}", SkipVariableReplacement = false}}
                    },
                    Outputs = new []
                    {
                        new WorkflowOutput
                        {
                            Name = "ticket_id",
                            Type = WorkflowOutputType.Text,
                            Label = "Ticket ID"
                        },
                        new WorkflowOutput
                        {
                            Name = "title",
                            Type = WorkflowOutputType.Text,
                            Label = "Title"
                        }
                    }
                }),
                "workflows.updateStep",
                jobject =>
                {
                    Assert.True(Utility.CompareJson(jobject, "Web_UpdateStepRequest.json"));
                });
        }
    }
}