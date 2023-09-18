using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class DomainRestrictions
{
    [JsonProperty("emails", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Emails { get; set; } = new();

    [JsonProperty("urls", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Urls { get; set; } = new();

    public bool ShouldSerializeEmails() => true;
    public bool ShouldSerializeUrls() => true;
}