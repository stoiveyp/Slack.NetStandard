using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Objects.Workflows;
using Slack.NetStandard.Objects.Workflows.FormElements;

namespace Slack.NetStandard.JsonConverters
{
    public class FormElementConverter:JsonConverter<FormElement>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, FormElement value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override FormElement ReadJson(JsonReader reader, Type objectType, FormElement existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            if (string.IsNullOrWhiteSpace(componentType))
            {
                return null;
            }
            var target = GetElement(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"Form element type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> FormElementLookup = new()
        {
            {WorkflowTypes.BuiltInTypes.String, typeof(StringFormElement)},
            {WorkflowTypes.BuiltInTypes.Boolean, typeof(BoolFormElement)}
        };

        private FormElement GetElement(string type)
        {
            return (FormElement)(
                FormElementLookup.TryGetValue(type, out var e)
                    ? Activator.CreateInstance(e)
                    : new FormElement());
        }
    }
}
