﻿using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.JsonConverters
{
    public class InteractionPayloadConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var target = GetPayloadType(jObject.Value<string>("type"));
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        internal static InteractionPayload GetPayloadType(string value)
        {
            return GetPayloadType(ToEnum(value));
        }

        internal static InteractionPayload GetPayloadType(InteractionType value)
        {
            return value switch
            {
                InteractionType.GlobalShortcut => new GlobalShortcutPayload(),
                InteractionType.InteractiveMessage => new InteractiveMessagePayload(),
                InteractionType.MessageAction => new MessageActionPayload(),
                InteractionType.BlockActions => new BlockActionsPayload(),
                InteractionType.ViewClosed => new ViewClosedPayload(),
                InteractionType.ViewSubmission => new ViewSubmissionPayload(),
#pragma warning disable CS0618 // Type or member is obsolete
                InteractionType.WorkflowStepEdit => new WorkflowStepEditPayload(),
#pragma warning restore CS0618 // Type or member is obsolete
                InteractionType.BlockSuggestion => new SuggestionPayload(),
                InteractionType.DialogSuggestion => new SuggestionPayload(),
                _ => (InteractionPayload)null
            };
        }

        private static InteractionType ToEnum(string str)
        {
            var enumType = typeof(InteractionType);
            if (string.IsNullOrWhiteSpace(str))
            {
                return InteractionType.MessageAction;
            }

            foreach (var name in Enum.GetNames(enumType))

            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).FirstOrDefault();
                if (enumMemberAttribute != null && enumMemberAttribute.Value == str) return (InteractionType)Enum.Parse(enumType, name);
            }

            return InteractionType.MessageAction;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(InteractionPayload).IsAssignableFrom(objectType);
        }
    }
}
