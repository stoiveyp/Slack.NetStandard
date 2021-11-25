﻿using System.Collections.Generic;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class UsersSelect:IMessageElement
    {
        public UsersSelect(){}

        public UsersSelect(string actionId, string placeholder)
        {
            ActionId = actionId;
            Placeholder = placeholder;
        }

        public const string ElementType = "users_select";
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_user",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialUser { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("focus_on_load", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }
    }
}