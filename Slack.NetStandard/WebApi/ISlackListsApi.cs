using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface ISlackListsApi
    {
        ISlackListsAccessApi Access { get; }
        ISlackListsDownloadApi Downloads { get; }
        ISlackListsItemsApi Items { get; }
        Task<SlackListCreateResponse> Create(SlackListCreateRequest request);
        Task<WebApiResponse> Update(SlackListUpdateRequest request);
        
    }
}
