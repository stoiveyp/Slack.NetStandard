using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Interaction;
using System.Linq;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class Features
{
    [JsonProperty("app_home",NullValueHandling = NullValueHandling.Ignore)]
    public AppHomeFeature AppHome { get; set; }

    [JsonProperty("bot_user",NullValueHandling = NullValueHandling.Ignore)]
    public BotUserFeature BotUser { get; set; }

    [JsonProperty("shortcuts",NullValueHandling = NullValueHandling.Ignore)]
    public IList<ShortcutFeature> Shortcuts { get; set; } = new List<ShortcutFeature>();

    [JsonProperty("slash_commands",NullValueHandling = NullValueHandling.Ignore)]
    public IList<SlackCommandFeature> SlashCommands { get; set; } = new List<SlackCommandFeature>();

    [JsonProperty("workflow_steps",NullValueHandling = NullValueHandling.Ignore)]
    public IList<WorkflowStepFeature> WorkflowSteps { get; set; } = new List<WorkflowStepFeature>();

    [JsonProperty("unfurl_domains", NullValueHandling = NullValueHandling.Ignore)]
    public IList<string> UnfurlDomains { get; set; } = new List<string>();

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }

    public bool ShouldSerializeShortcuts() => Shortcuts?.Any() ?? false;
    public bool ShouldSerializeWorkflowSteps() => WorkflowSteps?.Any() ?? false;
    public bool ShouldSerializeSlashCommands() => SlashCommands?.Any() ?? false;
    public bool ShouldSerializeUnfurlDomains() => UnfurlDomains?.Any() ?? false;
}