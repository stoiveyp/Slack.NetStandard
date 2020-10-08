﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class Checkboxes:IMessageElement
    {
        public string Type => nameof(Checkboxes).ToLower();

        [JsonProperty("action_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Option> Options { get; set; }

        [JsonProperty("initial_options", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IOption> InitialOptions { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

    }
}
