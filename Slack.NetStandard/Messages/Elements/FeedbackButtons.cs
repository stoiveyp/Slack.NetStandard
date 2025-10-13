using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages.Elements
{
    public class FeedbackButtons:IContextActionsElement
    {
        public const string ElementType = "feedback_buttons";
        
        public FeedbackButtons(){}

        public FeedbackButtons(FeedbackButton positiveButton, FeedbackButton negativeButton)
        {
            PositiveButton = positiveButton;
            NegativeButton = negativeButton;
        }
        
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("action_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }
        
        [JsonProperty("positive_button")]
        public FeedbackButton PositiveButton { get; set; }
        
        [JsonProperty("negative_button")]
        public FeedbackButton NegativeButton { get; set; }
    }
}
