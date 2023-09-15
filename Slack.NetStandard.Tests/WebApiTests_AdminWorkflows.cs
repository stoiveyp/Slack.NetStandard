using System.Threading.Tasks;
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
    }
}