﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.JsonConverters
{
    public class MessageElementConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            object target = GetComponent(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"MessageElement type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> IMessageElementLookup = new Dictionary<string, Type>
        {
            {nameof(Image).ToLower(), typeof(Image)},
            {nameof(Button).ToLower(), typeof(Button)},
            {nameof(Overflow).ToLower(),typeof(Overflow) },
            {nameof(DatePicker).ToLower(),typeof(DatePicker)},
            {StaticSelect.ElementType,typeof(StaticSelect) },
            {ExternalSelect.ElementType,typeof(ExternalSelect) },
            {UsersSelect.ElementType,typeof(UsersSelect) },
            {ConversationsSelect.ElementType,typeof(ConversationsSelect) },
            {ChannelsSelect.ElementType,typeof(ChannelsSelect) },
            {PlainTextInput.ElementType,typeof(PlainTextInput) },
            {RichTextSection.ElementType,typeof(RichTextSection) },
            {MultiStaticSelect.ElementType,typeof(MultiStaticSelect) },
            {MultiExternalSelect.ElementType,typeof(MultiExternalSelect) },
            {MultiUsersSelect.ElementType,typeof(MultiUsersSelect) },
            {MultiConversationsSelect.ElementType,typeof(MultiConversationsSelect) },
            {MultiChannelsSelect.ElementType,typeof(MultiChannelsSelect) }
        };

        private IMessageElement GetComponent(string type)
        {
            return (IMessageElement)(
                IMessageElementLookup.ContainsKey(type)
                    ? Activator.CreateInstance(IMessageElementLookup[type])
                    : null);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IMessageElement).IsAssignableFrom(objectType);
        }
    }
}