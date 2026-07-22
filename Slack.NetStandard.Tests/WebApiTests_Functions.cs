using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Functions;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_Functions
{
    [Fact]
    public async Task WorkflowsStepList()
    {
        var response = await Utility.AssertWebApi(c => c.Functions.WorkflowSteps.List(new ListWorkflowStepRequest("F123")
        {
            Workflow = "wflow",
            WorkflowAppId = "wappid",
            WorkflowId = "W123"
        }), "functions.workflows.steps.list", "Web_FunctionsWorkflowStepList.json", j =>
        {
            Assert.Equal("wflow", j.Value<string>("workflow"));
            Assert.Equal("W123", j.Value<string>("workflow_id"));
            Assert.Equal("wappid", j.Value<string>("workflow_app_id"));
            Assert.Equal("F123", j.Value<string>("function_id"));
        });

        Assert.Single(response.StepVersions);
    }

    [Fact]
    public async Task WorkflowsStepExportResponses()
    {
        await Utility.AssertWebApi(c => c.Functions.WorkflowSteps.ExportResponses(new ExportResponseWorkflowStepRequest("S123")
        {
            Workflow = "wflow",
            WorkflowAppId = "wappid",
            WorkflowId = "W123"
        }), "functions.workflows.steps.responses.export", j =>
        {
            Assert.Equal("wflow", j.Value<string>("workflow"));
            Assert.Equal("W123", j.Value<string>("workflow_id"));
            Assert.Equal("wappid", j.Value<string>("workflow_app_id"));
            Assert.Equal("S123", j.Value<string>("step_id"));
        });
    }
}