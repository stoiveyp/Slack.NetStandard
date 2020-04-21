using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Users;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Users
    {
        [Fact]
        public async Task Users_Conversations()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.Conversations(new UserConversationRequest{
                User= "W0B2345D"
            }), "users.conversations", "Web_ConversationsList.json", nvc =>
            {
                Assert.Equal("W0B2345D", nvc["user"]);
            });
        }

        [Fact]
        public async Task Users_DeletePhoto()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.DeletePhoto(), "users.deletePhoto",  Assert.Empty);
        }

        [Fact]
        public async Task Users_GetPresence()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.GetPresence("W1234"), "users.getPresence","Web_UsersGetPresence.json",
                nvc =>
                {
                    Assert.Equal("W1234",nvc["user"]);
                });
        }

        [Fact]
        public async Task Users_Identity()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.Identity(), "users.identity","Web_UsersIdentity.json", Assert.Empty);
        }

        [Fact]
        public async Task Users_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.Info("W1234"), "users.info", "Web_UsersInfo.json",
                nvc =>
                {
                    Assert.Equal("W1234", nvc["user"]);
                });
        }

        [Fact]
        public async Task Users_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.List("W1234",null,true), "users.list", "Web_UsersList.json",
                nvc =>
                {
                    Assert.Equal("W1234", nvc["cursor"]);
                    Assert.Equal("true", nvc["include_locale"]);
                });
        }

        [Fact]
        public async Task Users_LookupByEmail()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.LookupByEmail("s@s.com"), "users.lookupByEmail", "Web_UsersInfo.json",
                nvc =>
                {
                    Assert.Equal("s@s.com", nvc["email"]);
                });
        }

        [Fact]
        public async Task Users_SetPresence()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.SetPresence("away"), "users.setPresence", 
                nvc =>
                {
                    Assert.Equal("away", nvc["presence"]);
                });
        }

        [Fact]
        public async Task Users_ProfileGet()
        {
            await Utility.AssertEncodedWebApi(c => c.Users.Profile.Get("W12345"), "users.profile.get", "Web_UsersProfileGet.json",
                nvc =>
                {
                    Assert.Equal("W12345", nvc["user"]);
                });
        }

        [Fact]
        public async Task Users_ProfileSet()
        {
            await Utility.AssertWebApi(c => c.Users.Profile.Set(new UserProfileSetRequest
                {
                Profile = new UserProfileSet
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john@smith.com",
                    Fields = new Dictionary<string, FieldValue>
                    {
                        {"Xf06054BBB",new FieldValue("Barista","I make the coffee & the tea!")}
                    }
                }
                }), "users.profile.set", "Web_UsersProfileGet.json",
                j =>
                {
                    Utility.CompareJson(j, "Web_UsersProfileSet.json");
                });
        }
    }
}