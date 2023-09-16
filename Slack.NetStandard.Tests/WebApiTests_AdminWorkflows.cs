using System.Linq;
using System.Threading.Tasks;
using Slack.NetStandard.Objects.Workflows;
using Slack.NetStandard.WebApi.Admin;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminWorkflows
{
    [Fact]
    public async Task Admin_WorkflowsSearch()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Workflows.Search(new WorkflowSearchRequest() { }), "admin.workflows.search",
            "Web_AdminWorkflowSearchResponse.json",
            jo =>
            {

            });

        var allElements = response.Workflow.SelectMany(w => w.Steps).SelectMany(s => s.Inputs.Values.OfType<FormInputValue>())
            .SelectMany(s => s.Value.Elements);
        Assert.All(allElements, fe => Assert.Null(fe.OtherFields));
    }
}