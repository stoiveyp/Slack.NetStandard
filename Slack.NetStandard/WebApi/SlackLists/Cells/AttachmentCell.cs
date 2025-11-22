using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class AttachmentCell : SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("attachment")]
        public string[] Attachments { get; set; }
    }
}
