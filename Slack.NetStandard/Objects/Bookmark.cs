using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.WebApi.Bookmarks;

namespace Slack.NetStandard.Objects
{
    public class Bookmark
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("channel_id")]
        public string Channel { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("link",NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }

        [JsonProperty("emoji",NullValueHandling = NullValueHandling.Ignore)]
        public string Emoji { get; set; }

        [JsonProperty("icon_url",NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public BookmarkType Type { get; set; }

        [JsonProperty("entity_id",NullValueHandling = NullValueHandling.Ignore)]
        public string EntityId { get; set; }

        [JsonProperty("date_created",NullValueHandling = NullValueHandling.Ignore)]
        public long DateCreated { get; set; }

        [JsonProperty("date_updated",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateUpdated { get; set; }

        [JsonProperty("rank",NullValueHandling = NullValueHandling.Ignore)]
        public string Rank { get; set; }

        [JsonProperty("last_updated_by_user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string LastUpdatedByUserId { get; set; }

        [JsonProperty("last_updated_by_team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LastUpdatedByTeamId { get; set; }

        [JsonProperty("shortcut_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ShortcutId { get; set; }

        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}
