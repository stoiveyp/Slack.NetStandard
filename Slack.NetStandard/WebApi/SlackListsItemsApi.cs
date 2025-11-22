using Slack.NetStandard.WebApi.SlackLists;
using System.Collections.Generic;
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

        public Task<SlackListItemCreateResponse> Create(SlackListItemCreateRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> Delete(string listId, string itemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> DeleteMultiple(string listId, params string[] itemIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> DeleteMultiple(string listId, List<string> itemids)
        {
            throw new System.NotImplementedException();
        }

        public Task<SlackListsItemInfoResponse> Info(string listId, string itemId, bool? includeIsSubscribed = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<SlackListsItemsListResponse> List(string listId)
        {
            throw new System.NotImplementedException();
        }

        public Task<SlackListsItemsListResponse> List(string listId, string cursor)
        {
            throw new System.NotImplementedException();
        }

        public Task<SlackListsItemsListResponse> List(string listId, int limit)
        {
            throw new System.NotImplementedException();
        }

        public Task<SlackListsItemsListResponse> List(string listId, string cursor = null, int? limit = null, bool? archived = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<SlackListItemUpdateResponse> Update(string listId, List<SlackListsCellDefinition> cells)
        {
            throw new System.NotImplementedException();
        }
    }
}