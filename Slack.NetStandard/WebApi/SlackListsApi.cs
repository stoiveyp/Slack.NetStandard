using System.Threading.Tasks;
using Slack.NetStandard.WebApi.SlackLists;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    internal class SlackListsApi : ISlackListsApi
    {
        private readonly IWebApiClient _client;

        public SlackListsApi(IWebApiClient client)
        {
            _client = client;
            Access = new SlackListsAccessApi(client);
            Downloads = new SlackListsDownloadApi(client);
            Items = new SlackListsItemsApi(client);
        }

        public ISlackListsAccessApi Access { get; }

        public ISlackListsDownloadApi Downloads { get; }

        public ISlackListsItemsApi Items { get; }

        public Task<SlackListsCreateResponse> Create(SlackListsCreateRequest request)
        {
            return _client.MakeJsonCall<SlackListsCreateRequest, SlackListsCreateResponse>("slackLists.create", request);
        }

        public Task<WebApiResponse> Update(SlackListUpdateRequest request)
        {
            return _client.MakeJsonCall("slackLists.update", request);
        }
    }
}