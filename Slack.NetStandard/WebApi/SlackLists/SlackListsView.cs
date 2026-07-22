using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsView
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("is_locked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLocked { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public string Position { get; set; }

        [JsonProperty("columns")]
        [AcceptedArray]
        public SlackListsViewColumn[] Columns { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("stick_column_left", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StickColumnLeft { get; set; }

        [JsonProperty("is_all_items_view", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAllItemsView { get; set; }

        [JsonProperty("default_view_key", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultViewKey { get; set; }

        [JsonProperty("show_completed_items", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowCompletedItems { get; set; }
    }
}
