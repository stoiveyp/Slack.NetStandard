using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;
using Slack.NetStandard.WebApi.Usergroups;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Usergroups
    {
        [Fact]
        public async Task Usergroups_Create()
        {
            await Utility.AssertWebApi(c => c.Usergroups.Create(new UsergroupCreateRequest
            {
                Name="test group",
                IncludeCount = true
            }), "usergroups.create", "Web_UsergroupResponse.json", j =>
            {
                Assert.Equal("test group", j.Value<string>("name"));
                Assert.True(j.Value<bool>("include_count"));
            });
        }

        [Fact]
        public async Task Usergroups_Disable()
        {
            await Utility.AssertEncodedWebApi(c => c.Usergroups.Disable("S060",true), "usergroups.disable", "Web_UsergroupResponse.json", nvc =>
            {
                Assert.Equal("S060", nvc["usergroup"]);
                Assert.Equal("true",nvc["include_count"]);
            });
        }

        [Fact]
        public async Task Usergroups_Enable()
        {
            await Utility.AssertEncodedWebApi(c => c.Usergroups.Enable("S060", true), "usergroups.enable", "Web_UsergroupResponse.json", nvc =>
            {
                Assert.Equal("S060", nvc["usergroup"]);
                Assert.Equal("true", nvc["include_count"]);
            });
        }

        [Fact]
        public async Task Usergroups_Update()
        {
            await Utility.AssertWebApi(c => c.Usergroups.Update(new UsergroupUpdateRequest
            {
                Usergroup = "S060",
                Name = "test group",
                IncludeCount = true
            }), "usergroups.update", "Web_UsergroupResponse.json", j =>
            {
                Assert.Equal("S060", j.Value<string>("usergroup"));
                Assert.Equal("test group", j.Value<string>("name"));
                Assert.True(j.Value<bool>("include_count"));
            });
        }

        [Fact]
        public async Task Usergroups_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Usergroups.List(true, true, true), "usergroups.list", "Web_UsergroupListResponse.json", nvc =>
            {
                Assert.Equal("true", nvc["include_users"]);
                Assert.Equal("true", nvc["include_disabled"]);
                Assert.Equal("true", nvc["include_count"]);
            });
        }

        [Fact]
        public async Task Usergroups_Users_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Usergroups.Users.List("S060", true), "usergroups.users.list", "Web_UsergroupUserListResponse.json", nvc =>
            {
                Assert.Equal("S060", nvc["usergroup"]);
                Assert.Equal("true", nvc["include_disabled"]);
            });
        }

        [Fact]
        public async Task Usergroups_Users_Update()
        {
            await Utility.AssertEncodedWebApi(c => c.Usergroups.Users.Update("S060",new []{"W123","U234"}, true), "usergroups.users.update", "Web_UsergroupResponse.json", nvc =>
            {
                Assert.Equal("S060", nvc["usergroup"]);
                Assert.Equal("W123,U234", nvc["users"]);
                Assert.Equal("true", nvc["include_count"]);
            });
        }
    }
}