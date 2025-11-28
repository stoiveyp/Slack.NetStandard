using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.References
{
    public class FileReference : SlackListsReference
    {
        public FileReference() { }

        public FileReference(string fileId)
        {
            FileId = fileId;
        }

        [JsonProperty("file_id")]
        public string FileId { get; set; }
    }
}
