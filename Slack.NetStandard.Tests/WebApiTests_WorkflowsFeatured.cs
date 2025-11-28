using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_WorkflowsFeatured
    {
        [Fact]
        public async Task FeaturedWorkflow_Add()
        {
            var channelId = "C12345";
            var triggerId = "Ft012345";

            await Utility.AssertWebApi(
                c => c.Workflows.Featured.Add(channelId, triggerId),
                "workflows.featured.add",
                jobject =>
                {
                    Assert.Equal(channelId, jobject.Value<string>("channel_id"));
                    jobject.CompareJArray("trigger_ids", triggerId);
                });
        }

        [Fact]
        public async Task FeaturedWorkflow_Remove()
        {
            var channelId = "C12345";
            var triggerId = "Ft012345";

            await Utility.AssertWebApi(
                c => c.Workflows.Featured.Remove(channelId, triggerId),
                "workflows.featured.remove",
                jobject =>
                {
                    Assert.Equal(channelId, jobject.Value<string>("channel_id"));
                    jobject.CompareJArray("trigger_ids", triggerId);
                });
        }
        
        [Fact]
        public async Task FeaturedWorkflow_Set()
        {
            var channelId = "C12345";
            var triggerId = "Ft012345";

            await Utility.AssertWebApi(
                c => c.Workflows.Featured.Set(channelId, triggerId),
                "workflows.featured.set",
                jobject =>
                {
                    Assert.Equal(channelId, jobject.Value<string>("channel_id"));
                    jobject.CompareJArray("trigger_ids", triggerId);
                });
        }

        [Fact]
        public async Task FeaturedWorkflow_List()
        {
            var channel1 = "C12345";
            var channel2 = "C012345678";

            var response = await Utility.AssertWebApi(
                c => c.Workflows.Featured.List(channel1, channel2),
                "workflows.featured.list","Web_WorkflowsFeaturedList.json",
                jobject =>
                {
                    jobject.CompareJArray("channel_ids", channel1, channel2);
                });
        }
    }
}
