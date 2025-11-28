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
                InitialFields = [new SelectCellDefinition("Col1000000", ["OptHIGH123"])]
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

        [Fact]
        public async Task Update()
        {
            var fileId = "F1234567";
            await Utility.AssertWebApi(c => c.SlackLists.Items.Update(fileId, [new SelectCellDefinition("Col1000000", ["OptHIGH123"], "Row123")]),
                "slackLists.items.update",
                jo =>
                {
                    var fields = jo.Value<JArray>("cells").First;
                    Assert.Equal("Col1000000", fields.Value<string>("column_id"));
                    Assert.Equal("Row123", fields.Value<string>("row_id"));
                    var select = fields.Value<JArray>("select").First.Value<string>();
                    Assert.Equal("OptHIGH123", select);
                });
        }

        [Fact]
        public async Task Delete()
        {
            var fileId = "F1234567";
            var itemId = "Rec014K005UQJ";
            await Utility.AssertEncodedWebApi(c => c.SlackLists.Items.Delete(fileId, itemId),
                "slackLists.items.delete",
                nvc =>
                {
                    Assert.Equal(fileId, nvc["list_id"]);
                    Assert.Equal(itemId, nvc["id"]);
                });
        }

        [Fact]
        public async Task DeleteMultiple()
        {
            var fileId = "F1234567";
            var itemId = "Rec014K005UQJ";
            var itemId2 = "Rec014K005FF";
            await Utility.AssertWebApi(c => c.SlackLists.Items.DeleteMultiple(fileId, itemId, itemId2),
                "slackLists.items.deleteMultiple",
                jo =>
                {
                    Assert.Equal(fileId, jo.Value<string>("list_id"));
                    jo.CompareJArray("ids", itemId, itemId2);
                });
        }
    }
}