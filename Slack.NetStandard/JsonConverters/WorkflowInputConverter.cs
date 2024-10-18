using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.JsonConverters
{
    public class WorkflowInputConverter : SingleOrArrayConverter<JObject>
    {
        protected override JsonToken SingleToken => JsonToken.StartObject;

        protected override void ReadSingle(JsonReader reader, JsonSerializer serializer, List<JObject> list)
        {
            list.Add(JObject.Load(reader));
        }
    }
}