using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Calls;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Call
    {
        [Fact]
        public async Task Call_Start()
        {
            var call = Utility.ExampleFileContent<Call>("Web_CallsStart.json");
            await Utility.AssertWebApi(c => c.Calls.Start(call), "calls.add", "Web_CallsStart.json", jo =>
            {

            });
        }

        [Fact]
        public async Task Call_End()
        {
            await Utility.AssertWebApi(c => c.Calls.End("R123", 60), "calls.end", jo =>
            {
                Assert.Equal("R123", jo.Value<string>("id"));
                Assert.Equal(60, jo.Value<int>("duration"));
            });
        }

        [Fact]
        public async Task Call_Info()
        {
            await Utility.AssertWebApi(c => c.Calls.Info("R0E69JAIF"), "calls.info", "Web_CallsStart.json", jo =>
            {
                Assert.Equal("R0E69JAIF", jo.Value<string>("id"));
            });
        }

        [Fact]
        public async Task Call_Update()
        {
            await Utility.AssertWebApi(c => c.Calls.Update(new UpdateCallRequest
            {
                Id = "R0E69JAIF",
                DesktopAppJoinUrl = "test://test.com",
                JoinUrl = "test://test2.com",
                Title = "test call"
            }), "calls.update", "Web_CallsStart.json", jo =>
            {
                Assert.Equal("R0E69JAIF", jo.Value<string>("id"));
                Assert.Equal("test://test.com", jo.Value<string>("desktop_app_join_url"));
                Assert.Equal("test://test2.com", jo.Value<string>("join_url"));
                Assert.Equal("test call", jo.Value<string>("title"));
            });
        }

        [Fact]
        public async Task Call_ParticipantsAdd()
        {
            var call = Utility.ExampleFileContent<Call>("Web_CallsStart.json");
            await Utility.AssertWebApi(c => c.Calls.AddParticipant(new ModifyParticipantRequest
            {
                Id="R123",
                Users = call.Users
            }), "calls.participants.add",jo => {});
        }

        [Fact]
        public async Task Call_ParticipantsRemove()
        {
            var call = Utility.ExampleFileContent<Call>("Web_CallsStart.json");
            await Utility.AssertWebApi(c => c.Calls.RemoveParticipant(new ModifyParticipantRequest
            {
                Id = "R123",
                Users = call.Users
            }), "calls.participants.remove", jo => { });
        }
    }
}
