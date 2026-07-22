namespace Slack.NetStandard.Objects.Workflows;

public static class WorkflowTypes
{
    //https://github.com/slackapi/deno-slack-sdk/blob/main/src/schema/schema_types.ts
    public static class BuiltInTypes
    {
        public const string String = "string";
        public const string Boolean = "boolean";
        public const string Integer = "integer";
        public const string Number = "number";
        public const string Object = "object";
        public const string Array = "array";
    }

    public static class SlackTypes
    {
        //https://github.com/slackapi/deno-slack-sdk/blob/main/src/schema/slack/types/mod.ts
        //https://github.com/slackapi/deno-slack-sdk/blob/main/src/schema/slack/types/custom/message_context.ts
        private const string SlackId = "slack#/types/";
        public const string UserId = SlackId + "user_id";
        public const string Date = SlackId + "date";
        public const string ChannelId = SlackId + "channel_id";
        public const string UsergroupId = SlackId + "usergroup_id";
        public const string Timestamp = SlackId + "timestamp";
        public const string Blocks = SlackId + "blocks";
        public const string Interactivity = SlackId + "interactivity";
        public const string OAuth2 = SlackId + "credential/oauth2";
        public const string RichText = SlackId + "rich_text";
        public const string MessageTs = SlackId + "message_ts";
        public const string MessageContext = SlackId + "message_context";
        public const string FormInput = SlackId + "form_input_object";
        public const string UserContext = SlackId + "user_context";

    }
}