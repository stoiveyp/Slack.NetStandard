using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class Usergroup:SlackId
    {
        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("is_usergroup", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsUsergroup { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("handle", NullValueHandling = NullValueHandling.Ignore)]
        public string Handle { get; set; }

        [JsonProperty("is_external", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsExternal { get; set; }

        [JsonProperty("date_create", NullValueHandling = NullValueHandling.Ignore)]
        public long DateCreated { get; set; }

        [JsonProperty("date_update", NullValueHandling = NullValueHandling.Ignore)]
        public long? DateUpdated { get; set; }

        [JsonProperty("date_delete", NullValueHandling = NullValueHandling.Ignore)]
        public long? DateDelete { get; set; }

        [JsonProperty("auto_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AutoType { get; set; }

        [JsonProperty("created_by",NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty("updated_by",NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty("deleted_by",NullValueHandling = NullValueHandling.Ignore)]
        public string DeletedBy { get; set; }

        [JsonProperty("prefs",NullValueHandling = NullValueHandling.Ignore)]
        public UsergroupPreferences Prefs { get; set; }

        [JsonProperty("users",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Users { get; set; }

        [JsonProperty("user_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? UserCount { get; set; }
    }
}
