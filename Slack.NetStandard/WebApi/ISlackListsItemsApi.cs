using Slack.NetStandard.WebApi.SlackLists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface ISlackListsItemsApi
    {
        Task<SlackListItemCreateResponse> Create(SlackListItemCreateRequest request);
        Task<WebApiResponse> Delete(string listId, string itemId);
        Task<WebApiResponse> DeleteMultiple(string listId, params string[] itemIds);
        Task<WebApiResponse> DeleteMultiple(string listId, List<string> itemids);
        Task<SlackListsItemInfoResponse> Info(string listId, string itemId, bool? includeIsSubscribed = null);
        Task<SlackListsItemsListResponse> List(string listId);
        Task<SlackListsItemsListResponse> List(string listId, string cursor);
        Task<SlackListsItemsListResponse> List(string listId, int limit);
        Task<SlackListsItemsListResponse> List(string listId, string cursor = null, int? limit = null, bool? archived = null);

        Task<SlackListItemUpdateResponse> Update(string listId, List<SlackListCellDefinition> cells);
    }
}