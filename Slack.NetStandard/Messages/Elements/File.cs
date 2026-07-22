using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements;

public class Files : IMessageElement
{
    public static string ElementType = "file_input";
    public string Type => ElementType;

    public Files() { }

    public Files(string actionId)
    {
        ActionId = actionId;
    }

    [JsonProperty("action_id", NullValueHandling = NullValueHandling.Ignore)]
    public string ActionId { get; set; }

    [JsonProperty("filetypes", NullValueHandling = NullValueHandling.Ignore)]
    public IList<string> Filetypes { get; set; } = new List<string>();

    [JsonProperty("max_files", NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxFiles { get; set; }

    public bool ShouldSerializeFiletypes() => Filetypes.Any();
}