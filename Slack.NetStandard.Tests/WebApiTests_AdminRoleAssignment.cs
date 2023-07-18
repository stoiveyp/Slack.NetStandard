using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Admin;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminRoleAssignment
{
    [Fact]
    public async Task Admin_RolesAddAssignment()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Roles.AddAssignments(new ModifyRoleAssignmentRequest
        {
            EntityIds = new List<string> { "T00000001", "E00000002" },
            RoleId = "R001",
            UserIds = new List<string> { "U001", "U002" }
        }),"admin.roles.addAssignments", "Web_AdminRoleRejectedEntity.json", jo =>
            {
                Assert.Equal("R001", jo.Value<string>("role_id"));
                jo.CompareJArray("entity_ids", "T00000001", "E00000002");
                jo.CompareJArray("user_ids", "U001", "U002");
            });
        Assert.Equal("failed_for_some_entities",response.Error);
        var entity = Assert.Single(response.RejectedEntities);
        Assert.Equal("E123ABC456", entity.Id);
        Assert.Equal("invalid_auth", entity.Error);
    }

    [Fact]
    public async Task Admin_RolesListAssignment()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Roles.ListAssignments(new ListRoleAssignmentRequest
        {
            Cursor = "C123",
            Limit = 5,
            SortDirection = SortDirection.Ascending,
            EntityIds = new List<string>{ "T00000001", "E00000002" },
            RoleIds = new List<string>{ "R001", "R002" }
        }), "admin.roles.listAssignments", "Web_AdminRoleList.json", jo =>
        {

            Assert.Equal("C123", jo.Value<string>("cursor"));
            Assert.Equal("asc", jo.Value<string>("sort_dir"));
            Assert.Equal(5, jo.Value<int>("limit"));
            jo.CompareJArray("entity_ids", "T00000001", "E00000002");
            jo.CompareJArray("role_ids", "R001", "R002");
        });

        Assert.True(response.OK);
        Assert.Equal(5,response.RoleAssignments.Length);
        Assert.Equal("dXNlcl9pZDozMDA1NjIwNTc0MjYyO2VudGl0eV90eXBlOjE7ZW50aXR5X2lkOjMwMDUxODcyMTczNjY7ZGF0ZV9jcmVhdGU6MTY0MzIzMTMzMQ==",response.ResponseMetadata.NextCursor);
        var roleAssignment = response.RoleAssignments[2];
        Assert.Equal("Rl0A",roleAssignment.RoleId);
        Assert.Equal("C123ABC456", roleAssignment.EntityId);
        Assert.Equal("U123ABC456", roleAssignment.UserId);
        Assert.Equal(1666624374, roleAssignment.DateCreated);
    }

    [Fact]
    public async Task Admin_RolesRemoveAssignment()
    {
        var response = await Utility.AssertWebApi(c => c.Admin.Roles.RemoveAssignments(new ModifyRoleAssignmentRequest
        {
            EntityIds = new List<string> { "T00000001", "E00000002" },
            RoleId = "R001",
            UserIds = new List<string> { "U001", "U002" }
        }), "admin.roles.removeAssignments", "Web_AdminRoleRejectedEntity.json", jo =>
        {
            Assert.Equal("R001", jo.Value<string>("role_id"));
            jo.CompareJArray("entity_ids", "T00000001", "E00000002");
            jo.CompareJArray("user_ids", "U001", "U002");
        });
        Assert.Equal("failed_for_some_entities", response.Error);
        var entity = Assert.Single(response.RejectedEntities);
        Assert.Equal("E123ABC456", entity.Id);
        Assert.Equal("invalid_auth", entity.Error);
    }
}