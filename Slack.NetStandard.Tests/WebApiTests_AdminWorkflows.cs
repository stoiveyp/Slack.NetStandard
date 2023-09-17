using System.Linq;
using System.Threading.Tasks;
using Slack.NetStandard.Objects.Workflows;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Admin;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminWorkflows
{
    [Fact]
    public async Task Admin_WorkflowsSearch()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Workflows.Search(new WorkflowSearchRequest
            {
                AppId = "ABC123",
                NoCollaborators = true,
                SortDirection = SortDirection.Ascending,
                Query = "test"
            }), "admin.workflows.search",
            "Web_AdminWorkflowSearchResponse.json",
            jo =>
            {
                Assert.Equal("asc",jo.Value<string>("sort_dir"));
                Assert.True(jo.Value<bool>("no_collaborators"));
                Assert.Equal("ABC123",jo.Value<string>("app_id"));
                Assert.Equal("test",jo.Value<string>("query"));
            });

        var allElements = response.Workflow.SelectMany(w => w.Steps).SelectMany(s => s.Inputs.Values.OfType<FormInputValue>())
            .SelectMany(s => s.Value.Elements);
        Assert.All(allElements, fe => Assert.Null(fe.OtherFields));
    }

    [Fact]
    public async Task Admin_WorkflowPermissionLookup()
    {
        await Utility.AssertWebApi(c => c.Admin.Workflows.LookupPermissions(new[] { "ABC123" }, 3),
            "admin.workflows.permissions.lookup",
            "Web_AdminWorkflowPermissionLookup.json",
            jo =>
            {
                jo.CompareJArray("workflow_ids", "ABC123");
                Assert.Equal(3, jo.Value<int>("max_workflow_triggers"));
            });
    }

    [Fact]
    public async Task Admin_WorkflowUnpublish()
    {
        await Utility.AssertWebApi(c => c.Admin.Workflows.Unpublish(new[] { "ABC123" }),
            "admin.workflows.unpublish",
            jo =>
            {
                jo.CompareJArray("workflow_ids", "ABC123");
            });
    }

    [Fact]
    public async Task Admin_WorkflowAddCollaborator()
    {
        await Utility.AssertWebApi(c => c.Admin.Workflows.AddCollaborators(new[] { "C1234" }, new []{"ABC123"}),
            "admin.workflows.collaborators.add",
            jo =>
            {
                jo.CompareJArray("workflow_ids", "ABC123");
                jo.CompareJArray("collaborator_ids", "C1234");
            });
    }

    [Fact]
    public async Task Admin_WorkflowRemoveCollaborator()
    {
        await Utility.AssertWebApi(c => c.Admin.Workflows.RemoveCollaborators(new[] { "D1234" }, new []{"ABC123"}),
            "admin.workflows.collaborators.remove",
            jo =>
            {
                jo.CompareJArray("workflow_ids", "ABC123");
                jo.CompareJArray("collaborator_ids", "D1234");
            });
    }
}