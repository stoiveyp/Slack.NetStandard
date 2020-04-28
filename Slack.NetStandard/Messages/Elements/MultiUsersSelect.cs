﻿using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class MultiUsersSelect : IMessageElement
    {
        public const string ElementType = "multi_users_select";
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_users", NullValueHandling = NullValueHandling.Ignore)]
        public string[] InitialUsers { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("max_selected_items", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxSelectedItems { get; set; }
    }
}