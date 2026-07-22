using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsDownloadGetResponse : WebApiResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }
    }
}
