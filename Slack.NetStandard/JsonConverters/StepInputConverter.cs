using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Objects.Workflows;

namespace Slack.NetStandard.JsonConverters
{
    public class StepInputConverter:JsonConverter<StepInput>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, StepInput value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override StepInput ReadJson(JsonReader reader, Type objectType, StepInput existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var tempObj = (JObject)JObject.ReadFrom(reader);

            var obj = CalculateInputType(tempObj);
            var objReader = tempObj.CreateReader();
            serializer.Populate(objReader, obj);
            return obj;
        }

        private StepInput CalculateInputType(JObject tempObj)
        {
            var valueType = tempObj["value"].Type;
            if (valueType is JTokenType.String)
            {
                return new StringStepInput();
            }

            if (valueType is JTokenType.Array)
            {
                var array = tempObj["value"].Value<JArray>();
                if (array.Count == 0)
                {
                    return null;
                }

                if (array[0].First.Type == JTokenType.String)
                {
                    return new StringArrayStepInput();
                }

                var blocks = new BlockValue();
                return blocks;
            }

            if (valueType is JTokenType.Object)
            {
                return new FormInputValue();
            }

            return new StepInput();
        }
    }
}
