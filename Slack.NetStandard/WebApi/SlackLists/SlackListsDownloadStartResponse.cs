using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsDownloadStartResponse: WebApiResponse
    {
        [JsonProperty("job_id")]
        public string JobId { get; set; }
    }
}
