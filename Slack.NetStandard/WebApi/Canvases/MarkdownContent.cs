using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases
{
    public class MarkdownContent:CanvasContent
    {
        public MarkdownContent(string markdown)
        {
            Markdown = markdown;
        }

        [JsonProperty("markdown")]
        public string Markdown { get; set; }

        [JsonProperty("type")]
        public override string Type => "markdown";
    }
}
