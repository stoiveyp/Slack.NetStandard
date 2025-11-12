using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface ISlackListsDownloadApi
    {
        Task<SlackListsDownloadGetResponse> Get(string listId, string jobId);
        Task<SlackListsDownloadStartResponse> Start(string listId, bool? includeArchived = null);
    }
}