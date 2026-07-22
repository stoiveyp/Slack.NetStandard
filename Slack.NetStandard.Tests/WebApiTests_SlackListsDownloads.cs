using Slack.NetStandard.WebApi.SlackLists;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_SlackListsDownloads
    {
        [Fact]
        public async Task Start()
        {
            var response = await Utility.AssertWebApi(c => c.SlackLists.Downloads.Start(
                "F123456", true), "slackLists.download.start", jo =>
                {
                    Assert.Equal("F123456", jo.Value<string>("list_id"));
                    Assert.True(jo.Value<bool>("include_archived"));
                }, new SlackListsDownloadStartResponse
                {
                    JobId = "J1234"
                });

            Assert.Equal("J1234", response.JobId);
        }

        [Fact]
        public async Task Get()
        {
            var response = await Utility.AssertWebApi(c => c.SlackLists.Downloads.Get(
                "F123456", "J1234"), "slackLists.download.get", jo =>
                {
                    Assert.Equal("F123456", jo.Value<string>("list_id"));
                    Assert.Equal("J1234", jo.Value<string>("job_id"));
                }, new SlackListsDownloadGetResponse { DownloadUrl = "https://test.com",Status = "COMPLETE"});

            Assert.Equal("COMPLETE", response.Status);
            Assert.Equal("https://test.com", response.DownloadUrl);
        }
    }
}