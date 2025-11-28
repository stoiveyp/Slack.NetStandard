using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsLimits
    {
        [JsonProperty("over_row_maximum", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OverRowMaximum { get; set; }

        [JsonProperty("row_count_limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? RowCountLimit { get; set; }

        [JsonProperty("row_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? RowCount { get; set; }

        [JsonProperty("archived_row_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ArchivedRowCount { get; set; }

        [JsonProperty("over_column_maximum", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OverColumnMaximum { get; set; }

        [JsonProperty("column_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ColumnCount { get; set; }

        [JsonProperty("column_count_limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? ColumnCountLimit { get; set; }

        [JsonProperty("over_view_maximum", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OverViewMaximum { get; set; }

        [JsonProperty("view_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ViewCount { get; set; }

        [JsonProperty("view_count_limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? ViewCountLimit { get; set; }

        [JsonProperty("max_attachments_per_cell", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxAttachmentsPerCell { get; set; }
    }
}