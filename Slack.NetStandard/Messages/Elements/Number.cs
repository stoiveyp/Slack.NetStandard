using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class Number:IMessageElement
    {
        public static string ElementType = "number_input";
        public string Type => ElementType;

        public Number() { }

        public Number(string actionId)
        {
            ActionId = actionId;
        }

        public Number(string actionId, bool isDecimalAllowed) : this(actionId)
        {
            IsDecimalAllowed = isDecimalAllowed;
        }

        public Number(string actionId, string initialValue) : this(actionId)
        {
            InitialValue = initialValue;
        }

        public Number(string actionId, bool isDecimalAllowed, string initialValue) : this(actionId)
        {
            IsDecimalAllowed = isDecimalAllowed;
            InitialValue = initialValue;
        }

        [JsonProperty("is_decimal_allowed")]
        public bool IsDecimalAllowed { get; set; }

        [JsonProperty("action_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("placeholder",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Placeholder { get; set; }

        [JsonProperty("initial_value",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialValue { get; set; }

        [JsonProperty("min_value",NullValueHandling = NullValueHandling.Ignore)]
        public string MinValue { get; set; }

        [JsonProperty("max_value",NullValueHandling = NullValueHandling.Ignore)]
        public string MaxValue { get; set; }

        [JsonProperty("dispatch_action_config",NullValueHandling = NullValueHandling.Ignore)]
        public DispatchActionConfig DispatchActionConfig { get; set; }

        [JsonProperty("focus_on_load",NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }

    }
}
