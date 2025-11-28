using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.References
{
    public class CanvasReference : SlackListsReference
    {
        public CanvasReference() { }

        public CanvasReference(string fileId, string sectionId)
        {
            FileId = fileId;
        }

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("section_id")]
        public string SectionId { get; set; }
    }
}
