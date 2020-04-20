using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Reminders
    {
        [Fact]
        public async Task Reminders_Add()
        {
            await Utility.AssertWebApi(c => c.Reminders.Add("eat something", "every day", "U1234"), "reminders.add","Web_RemindersAdd.json", j =>
            {
                Assert.Equal("U1234", j.Value<string>("user"));
                Assert.Equal("every day", j.Value<string>("time"));
                Assert.Equal("eat something", j.Value<string>("text"));
                
            });
        }

        [Fact]
        public async Task Reminders_Complete()
        {
            await Utility.AssertEncodedWebApi(c => c.Reminders.Complete("Rm1234"), "reminders.complete",  nvc =>
            {
                Assert.Equal("Rm1234", nvc["reminder"]);

            });
        }

        [Fact]
        public async Task Reminders_Delete()
        {
            await Utility.AssertEncodedWebApi(c => c.Reminders.Delete("Rm1234"), "reminders.delete", nvc =>
            {
                Assert.Equal("Rm1234", nvc["reminder"]);

            });
        }

        [Fact]
        public async Task Reminders_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Reminders.Info("Rm1234"), "reminders.info", "Web_RemindersAdd.json", nvc =>
            {
                Assert.Single(nvc);
                Assert.Equal("Rm1234", nvc["reminder"]);

            });
        }

        [Fact]
        public async Task Reminders_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Reminders.List(), "reminders.list", "Web_RemindersList.json", nvc =>
            {
                Assert.Empty(nvc);
            });
        }
    }
}