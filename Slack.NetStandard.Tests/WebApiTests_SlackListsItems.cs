using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.SlackLists.CellDefinition;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_SlackListsItems
    {
        [Fact]
        public async Task Info()
        {
            var fileId = "F1234567";
            var itemId = "Rec014K005UQJ";
            await Utility.AssertWebApi(c => c.SlackLists.Items.Info("F1234567", itemId, true), "slackLists.items.info",
                "Web_SlackListsInfoResponse.json", jo =>
                {
                    Assert.Equal(fileId, jo.Value<string>("list_id"));
                    Assert.Equal(itemId, jo.Value<string>("id"));
                    Assert.True(jo.Value<bool>("include_is_subscribed"));
                });
        }

        [Fact]
        public async Task Create()
        {
            var fileId = "F1234567";
            var itemId = "Rec014K005UQJ";
            await Utility.AssertWebApi(c => c.SlackLists.Items.Create(new SlackListsItemCreateRequest
            {
                ListId = fileId,
                ParentItemId = itemId,
                InitialFields = [new SelectCellDefinition("Col1000000",["OptHIGH123"])]
            }), "slackLists.items.create",
                "Web_SlackListsItemsCreateResponse.json", jo =>
                {
                    Assert.Equal(fileId, jo.Value<string>("list_id"));
                    Assert.Equal(itemId, jo.Value<string>("parent_item_id"));
                    var fields = jo.Value<JArray>("initial_fields").First;
                    Assert.Equal("Col1000000", fields.Value<string>("column_id"));
                    var select = fields.Value<JArray>("select").First.Value<string>();
                    Assert.Equal("OptHIGH123", select);
                });
        }
    }
}