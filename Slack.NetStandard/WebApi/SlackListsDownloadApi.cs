using Slack.NetStandard.WebApi.SlackLists;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class SlackListsDownloadApi : ISlackListsDownloadApi
    {
        private readonly IWebApiClient _client;

        public SlackListsDownloadApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<SlackListsDownloadGetResponse> Get(string listId, string jobId)
        {
            throw new System.NotImplementedException();
        }

        public Task<SlackListsDownloadStartResponse> Start(string listId, bool? includeArchived = null)
        {
            throw new System.NotImplementedException();
        }
    }
}