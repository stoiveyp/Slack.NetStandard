using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.JsonConverters
{
    public class AuthorizationConverter:SingleOrArrayConverter<Authorization>
    {
        protected override JsonToken SingleToken => JsonToken.StartObject;
        protected override void ReadSingle(JsonReader reader, JsonSerializer serializer, List<Authorization> list)
        {
            var item = serializer.Deserialize<Authorization>(reader);
            list.Add(item);
        }
    }
}
