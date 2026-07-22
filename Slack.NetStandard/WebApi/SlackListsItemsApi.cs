using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class SlackListsItemsApi : ISlackListsItemsApi
    {
        private readonly IWebApiClient _client;

        public SlackListsItemsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<SlackListItemsCreateResponse> Create(SlackListsItemCreateRequest request)
        {
            return _client.MakeJsonCall<SlackListsItemCreateRequest, SlackListItemsCreateResponse>("slackLists.items.create", request);
        }

        public Task<WebApiResponse> Delete(string listId, string itemId)
        {
            return _client.MakeUrlEncodedCall<WebApiResponse>("slackLists.items.delete", new Dictionary<string, object>
            {
                {"list_id", listId },
                {"id", itemId }
            });
        }

        public Task<WebApiResponse> DeleteMultiple(string listId, params string[] itemIds)
        {
            return DeleteMultiple(listId, itemIds.ToList());
        }

        public Task<WebApiResponse> DeleteMultiple(string listId, List<string> itemids)
        {
            return _client.MakeJsonCall("slackLists.items.deleteMultiple", new JObject()
            {
                new JProperty("list_id",listId),
                new JProperty("ids", itemids)
            });
        }

        public Task<SlackListsItemInfoResponse> Info(string listId, string itemId, bool? includeIsSubscribed = null)
        {
            var jo = new JObject()
            {
                new JProperty("list_id",listId),
                new JProperty("id", itemId)
            };

            if (includeIsSubscribed.HasValue) { 
                jo.Add("include_is_subscribed", includeIsSubscribed.Value);
            }

            return _client.MakeJsonCall<JObject, SlackListsItemInfoResponse>("slackLists.items.info", jo);
        }

        public Task<SlackListsItemsListResponse> List(string listId)
        {
            return List(listId, null, null, null);
        }

        public Task<SlackListsItemsListResponse> List(string listId, string cursor)
        {
            return List(listId, cursor, null, null);
        }

        public Task<SlackListsItemsListResponse> List(string listId, int limit)
        {
            return List(listId, null, limit, null);
        }

        public Task<SlackListsItemsListResponse> List(string listId, string cursor = null, int? limit = null, bool? archived = null)
        {
            var jo = new JObject
            {
                { "list_id", listId }
            };
            if (archived.HasValue)
            {
                jo.Add("archived", archived.Value);
            }
            jo.AddPaging(cursor, limit);
            return _client.MakeJsonCall<JObject, SlackListsItemsListResponse>("slackLists.items.list", jo);
        }

        public Task<SlackListsItemUpdateResponse> Update(string listId, List<ISlackCellUpdateDefinition> cells)
        {
            return _client.MakeJsonCall<SlackListsItemUpdateRequest,SlackListsItemUpdateResponse>("slackLists.items.update", new SlackListsItemUpdateRequest(listId, cells));
        }
    }
}