using Newtonsoft.Json.Linq;
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
            return _client.MakeJsonCall<JObject, SlackListsDownloadGetResponse>("slackLists.download.get", new JObject()
            {
                new JProperty("list_id", listId),
                new JProperty("job_id", jobId)
            });
        }

        public Task<SlackListsDownloadStartResponse> Start(string listId, bool? includeArchived = null)
        {
            var jo = new JObject()
            {
                new JProperty("list_id", listId),
            };

            if (includeArchived.HasValue)
            {
                jo.Add("include_archived", includeArchived.Value);
            }

            return _client.MakeJsonCall<JObject, SlackListsDownloadStartResponse>("slackLists.download.get", jo);
        }
    }
}