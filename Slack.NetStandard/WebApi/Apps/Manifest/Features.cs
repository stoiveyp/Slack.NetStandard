using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class Features
{
    [JsonProperty("app_home",NullValueHandling = NullValueHandling.Ignore)]
    public AppHomeFeature AppHome { get; set; }

    [JsonProperty("bot_user",NullValueHandling = NullValueHandling.Ignore)]
    public BotUserFeature BotUser { get; set; }

    [JsonProperty("shortcuts",NullValueHandling = NullValueHandling.Ignore)]
    public ShortcutFeature[] Shortcuts { get; set; }

    [JsonProperty("slash_commands",NullValueHandling = NullValueHandling.Ignore)]
    public SlackCommandFeature[] SlashCommands { get; set; }

    [JsonProperty("workflow_steps",NullValueHandling = NullValueHandling.Ignore)]
    public WorkflowStepFeature[] WorkflowSteps { get; set; }

    [JsonProperty("unfurl_domains", NullValueHandling = NullValueHandling.Ignore)]
    public string[] UnfurlDomains { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }
}