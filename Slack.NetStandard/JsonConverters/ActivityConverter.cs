using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Apps;

namespace Slack.NetStandard.JsonConverters;

public class ActivityConverter : JsonConverter
{
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jObject = JObject.Load(reader);
        var eventType = jObject.Value<string>("event_type");
        var target = Activator.CreateInstance(typeof(Activity<>).MakeGenericType(GetEventType(eventType)));
        serializer.Populate(jObject.CreateReader(), target);
        return target;
    }

    private Type GetEventType(string eventType) => eventType switch
    {
        "function_execution_started" => typeof(FunctionExecutionStartedPayload),
        "function_execution_result" => typeof(FunctionExecutionResultPayload),
        "function_execution_output" => typeof(FunctionExecutionOutputPayload),
        "function_deployment" => typeof(FunctionDeploymentPayload),
        "platform_notification" => typeof(PlatformNotificationPayload),
        "workflow_bot_invited" => typeof(WorkflowBotInvitedPayload),
        "workflow_execution_started" => typeof(WorkflowExecutionStartedPayload),
        "workflow_execution_result" => typeof(WorkflowExecutionResultPayload),
        "workflow_step_started" => typeof(WorkflowStepStartedPayload),
        "workflow_published" => typeof(WorkflowPublishedPayload),
        "workflow_unpublished" => typeof(WorkflowUnpublishedPayload),
        "workflow_step_execution_result" => typeof(WorkflowStepExecutionResultPayload),
        "workflow_created_from_template" => typeof(WorkflowCreatedFromTemplatePayload),
        "trigger_executed" => typeof(TriggerExecutedPayload),
        "external_auth_started" => typeof(ExternalAuthStartedPayload),
        "external_auth_result" => typeof(ExternalAuthResultPayload),
        "external_auth_token_fetch_result" => typeof(ExternalAuthTokenFetchResultPayload),
        "external_auth_missing_function" => typeof(ExternalAuthMissingFunctionPayload),
        "external_auth_missing_selected_auth" => typeof(ExternalAuthMissingSelectedAuthPayload),
        "workflow_billing_result" => typeof(WorkflowBillingResultPayload),
        _ => typeof(Dictionary<string, object>)
    };

    public override bool CanConvert(Type objectType) => objectType == typeof(Activity);
}