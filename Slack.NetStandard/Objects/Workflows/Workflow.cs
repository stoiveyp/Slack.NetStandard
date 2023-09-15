using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows
{
    public class Workflow
    {
        //https://github.com/slackapi/java-slack-sdk/blob/main/slack-api-model/src/main/java/com/slack/api/model/admin/AppWorkflow.java#L11
        //https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("workflow_function_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowFunctionId { get; set; }

        [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("input_parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, InputParameter> InputParameters { get; set; } = new();

        [JsonProperty("output_parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, OutputParameter> OutputParameters { get; set; } = new();

        [JsonProperty("steps",NullValueHandling = NullValueHandling.Ignore)]
        public List<WorkflowStep> Steps { get; set; } = new ();

        [JsonProperty("collaborators", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Collaborators { get; set; } = new();

        [JsonProperty("icons", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Icons { get; set; } = new();

        [JsonProperty("is_published",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPublished { get; set; }

        [JsonProperty("last_updated_by",NullValueHandling = NullValueHandling.Ignore)]
        public string LastUpdatedBy { get; set; }

        [JsonProperty("unpublished_change_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? UnpublishedChangeCount { get; set; }

        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("source",NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("billing_type",NullValueHandling = NullValueHandling.Ignore)]
        public string BillingType { get; set; }

        [JsonProperty("last_published_version_id",NullValueHandling = NullValueHandling.Ignore)]
        public string LastPublishedVersionId { get; set; }

        [JsonProperty("last_published_date",NullValueHandling = NullValueHandling.Ignore)]
        public string LastPublishedDate { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }

        public bool ShouldSerializeInputParameters() => InputParameters?.Any() ?? false;
        public bool ShouldSerializeOutputParameters() => OutputParameters?.Any() ?? false;
        public bool ShouldSerializeSteps() => Steps?.Any() ?? false;
        public bool ShouldSerializeCollaborators() => Collaborators?.Any() ?? false;
        public bool ShouldSerializeIcons() => Icons?.Any() ?? false;
    }
}
