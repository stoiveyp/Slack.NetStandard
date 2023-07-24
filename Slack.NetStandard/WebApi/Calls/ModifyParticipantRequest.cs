using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Calls;

public class ModifyParticipantRequest
{
    public ModifyParticipantRequest(){}

    public ModifyParticipantRequest(string id)
    {
        Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("users")] public List<CallUser> Users { get; set; } = new();

    public bool ShouldSerializeUsers() => Users?.Any() ?? false;
}