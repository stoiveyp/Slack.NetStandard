using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminFunctions
{
    [Fact]
    public async Task Admin_FunctionsList()
    {
        await Utility.AssertWebApi(c => c.Admin.Functions.List(new FunctionListRequest
            {
                AppIds = new List<string> { "A1234" },
                Cursor = "C12324",
                Limit = 5,
                TeamId = "T1234"
            }),
            "admin.functions.list",
            "Web_AdminFunctionsList.json",
            jo =>
            {
                jo.CompareJArray("app_ids","A1234");
                Assert.Equal("C12324", jo.Value<string>("cursor"));
                Assert.Equal("T1234", jo.Value<string>("team_id"));
                Assert.Equal(5, jo.Value<int>("limit"));
            }
        );
    }

    [Fact]
    public async Task Admin_FunctionsPermissionLookup()
    {
        await Utility.AssertWebApi(c => c.Admin.Functions.PermissionLookup("F12324"),
            "admin.functions.permissions.lookup",
            "Web_AdminFunctionPermissionLookup.json", 
            jo =>
            {
                jo.CompareJArray("function_ids","F12324");
            });
    }

    [Fact]
    public async Task Admin_FunctionsPermissionSet()
    {
        await Utility.AssertWebApi(c => c.Admin.Functions.SetPermission("F1234", "everyone", "U1234", "U2345"),
            "admin.functions.permissions.set",
            jo =>
            {
                Assert.Equal("F1234",jo.Value<string>("function_id"));
                Assert.Equal("everyone",jo.Value<string>("visibility"));
                jo.CompareJArray("user_ids","U1234","U2345");
            });
    }
}