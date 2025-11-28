using Slack.NetStandard.WebApi.SlackLists;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface ISlackListsApi
    {
        ISlackListsAccessApi Access { get; }
        ISlackListsDownloadApi Downloads { get; }
        ISlackListsItemsApi Items { get; }
        Task<SlackListsCreateResponse> Create(SlackListsCreateRequest request);
        Task<WebApiResponse> Update(SlackListUpdateRequest request);
        
    }
}
