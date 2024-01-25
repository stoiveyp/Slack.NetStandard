using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Usergroups
    {
        [Fact]
        public async Task Usergroups_Create()
        {
            await Utility.AssertWebApi(
                c => c.Usergroups.Create(new UsergroupCreateRequest
                {
                    Name = "test group", IncludeCount = true, TeamId = "T12345"
                }), "usergroups.create", "Web_UsergroupResponse.json", j =>
                {
                    Assert.Equal("test group", j.Value<string>("name"));
                    Assert.True(j.Value<bool>("include_count"));
                    Assert.Equal("T12345", j.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Usergroups_Disable()
        {
            await Utility.AssertEncodedWebApi(
                c => c.Usergroups.Disable(new UsergroupDisableRequest
                {
                    Usergroup = "S060", IncludeCount = true, TeamId = "T12345"
                }), "usergroups.disable", "Web_UsergroupResponse.json", nvc =>
                {
                    Assert.Equal("S060", nvc["usergroup"]);
                    Assert.Equal("true", nvc["include_count"]);
                    Assert.Equal("T12345", nvc["team_id"]);
                });
        }

        [Fact]
        public async Task Usergroups_Enable()
        {
            await Utility.AssertEncodedWebApi(
                c => c.Usergroups.Enable(new UsergroupEnableRequest
                {
                    Usergroup = "S060", IncludeCount = true, TeamId = "T12345"
                }), "usergroups.enable", "Web_UsergroupResponse.json", nvc =>
                {
                    Assert.Equal("S060", nvc["usergroup"]);
                    Assert.Equal("true", nvc["include_count"]);
                    Assert.Equal("T12345", nvc["team_id"]);
                });
        }

        [Fact]
        public async Task Usergroups_Update()
        {
            await Utility.AssertWebApi(
                c => c.Usergroups.Update(new UsergroupUpdateRequest
                {
                    Usergroup = "S060", Name = "test group", IncludeCount = true, TeamId = "T12345"
                }), "usergroups.update", "Web_UsergroupResponse.json", j =>
                {
                    Assert.Equal("S060", j.Value<string>("usergroup"));
                    Assert.Equal("test group", j.Value<string>("name"));
                    Assert.True(j.Value<bool>("include_count"));
                    Assert.Equal("T12345", j.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Usergroups_List()
        {
            await Utility.AssertEncodedWebApi(
                c => c.Usergroups.List(new UsergroupListRequest
                {
                    IncludeCount = true, IncludeDisabled = true, IncludeUsers = true, TeamId = "T12345"
                }), "usergroups.list", "Web_UsergroupListResponse.json", nvc =>
                {
                    Assert.Equal("true", nvc["include_users"]);
                    Assert.Equal("true", nvc["include_disabled"]);
                    Assert.Equal("true", nvc["include_count"]);
                    Assert.Equal("T12345", nvc["team_id"]);
                });
        }

        [Fact]
        public async Task Usergroups_Users_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Usergroups.Users.List("S060", true, "T12345"),
                "usergroups.users.list", "Web_UsergroupUserListResponse.json", nvc =>
                {
                    Assert.Equal("S060", nvc["usergroup"]);
                    Assert.Equal("true", nvc["include_disabled"]);
                    Assert.Equal("T12345", nvc["team_id"]);
                });
        }

        [Fact]
        public async Task Usergroups_Users_Update()
        {
            await Utility.AssertEncodedWebApi(
                c => c.Usergroups.Users.Update("S060", new[] { "W123", "U234" }, true, "T12345"),
                "usergroups.users.update", "Web_UsergroupResponse.json", nvc =>
                {
                    Assert.Equal("S060", nvc["usergroup"]);
                    Assert.Equal("W123,U234", nvc["users"]);
                    Assert.Equal("true", nvc["include_count"]);
                    Assert.Equal("T12345", nvc["team_id"]);
                });
        }
    }
}