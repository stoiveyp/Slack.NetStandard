using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("updated_by", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty("updated_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpdatedTimestamp { get; set; }

        [JsonProperty("fields")]
        [AcceptedArray]
        public SlackListsCell[] Fields { get; set; }
    }
}
