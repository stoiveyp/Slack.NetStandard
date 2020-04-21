using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Dnd
    {
        [Fact]
        public async Task Dnd_EndDnd()
        {
            await Utility.AssertEncodedWebApi(c => c.Dnd.End(), "dnd.endDnd", nvc => Assert.Empty(nvc));
        }

        [Fact]
        public async Task Dnd_EndSnooze()
        {
            await Utility.AssertEncodedWebApi(c => c.Dnd.EndSnooze(), "dnd.endSnooze","Web_DndStatus.json", nvc => Assert.Empty(nvc));
        }

        [Fact]
        public async Task Dnd_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Dnd.Info("C123"), "dnd.info", "Web_DndStatus.json", nvc =>
                {
                    Assert.Single(nvc);
                    Assert.Equal("C123",nvc["user"]);
                });
        }

        [Fact]
        public async Task Dnd_SetSnooze()
        {
            await Utility.AssertEncodedWebApi(c => c.Dnd.SetSnooze(1), "dnd.setSnooze", "Web_DndStatus.json", nvc =>
            {
                Assert.Single(nvc);
                Assert.Equal("1", nvc["num_minutes"]);
            });
        }

        [Fact]
        public async Task Dnd_TeamInfo()
        {
            await Utility.AssertEncodedWebApi(c => c.Dnd.TeamInfo("W123","W234"), "dnd.teamInfo", "Web_DndTeamInfo.json", nvc =>
            {
                Assert.Single(nvc);
                Assert.Equal("W123,W234", nvc["users"]);
            });
        }
    }
}
