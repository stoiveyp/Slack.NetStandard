using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements
{
    public class IconButton:IContextActionsElement
    {
        public const string ElementType = "icon_button";
        
        public IconButton(){}

        public IconButton(string icon, string text, string actionId)
        {
            Icon = icon;
            Text = text;
            ActionId = actionId;
        }

        [JsonProperty("type")]
        public string Type => ElementType;

        [JsonProperty("text")]
        public PlainText Text { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("action_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
        
        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("accessibility_label", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessibilityLabel { get; set; }
        
        [JsonProperty("visible_to_user_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> VisibleToUserIds { get; set; } = new List<string>();

        public bool ShouldSerializeVisibleToUserIds() => VisibleToUserIds?.Any() ?? false;
    }
}
