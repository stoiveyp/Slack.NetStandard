using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.CellDefinition;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_SlackLists
    {
        [Fact]
        public async Task Items_Info()
        {
            var fileId = "F1234567";
            var itemId = "Rec014K005UQJ";
            await Utility.AssertEncodedWebApi(c => c.SlackLists.Items.Info("F1234567", itemId, true), "slackLists.items.info",
                "Web_SlackListsInfoResponse.json", nvc =>
                {
                    Assert.Equal(fileId, nvc["list_id"]);
                    Assert.Equal(itemId, nvc["item_id"]);
                    Assert.Equal(true.ToString(), nvc["include_is_subscribed"]);
                });
        }

        [Fact]
        public async Task Items_Create()
        {
            var fileId = "F1234567";
            var itemId = "Rec014K005UQJ";
            await Utility.AssertEncodedWebApi(c => c.SlackLists.Items.Create(new SlackListItemCreateRequest
            {
                ListId = fileId,
                ParentItemId = itemId,
                InitialFields = [new SelectCellDefinition("Col1000000",["OptHIGH123"])]
            }), "slackLists.items.create",
                "Web_SlackListsInfoResponse.json", nvc =>
                {
                    Assert.Equal(fileId, nvc["list_id"]);
                    Assert.Equal(itemId, nvc["item_id"]);
                    Assert.Equal(true.ToString(), nvc["include_is_subscribed"]);
                });
        }
    }
}