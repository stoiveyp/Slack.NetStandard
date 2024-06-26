using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using Slack.NetStandard.WebApi.Canvases;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Canvases.Operations;

namespace Slack.NetStandard.JsonConverters
{
    public class CanvasOperationConverter : JsonConverter<CanvasOperation>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, CanvasOperation value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override CanvasOperation ReadJson(JsonReader reader, Type objectType, CanvasOperation existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var eventType = jObject.Value<string>("operation");
            var target = GetOperationType(eventType);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        private CanvasOperation GetOperationType(string operationType) => operationType switch
        {
            CanvasOperationType.Delete => new Delete(),
            CanvasOperationType.Replace => new Replace(),
            CanvasOperationType.InsertAtStart => new InsertAtStart(),
            CanvasOperationType.InsertAtEnd => new InsertAtEnd(),
            CanvasOperationType.InsertBefore => new InsertBefore(),
            CanvasOperationType.InsertAfter => new InsertAfter(),
            _ => new CanvasOperation(operationType)
        };


    }
}
