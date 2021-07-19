using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.JsonConverters
{
    public class TeamConverter : SingleOrArrayConverter<Team>
    {
        protected override JsonToken SingleToken => JsonToken.StartObject;
        protected override void ReadSingle(JsonReader reader, JsonSerializer serializer, List<Team> list)
        {
            var item = serializer.Deserialize<Team>(reader);
            list.Add(item);
        }
    }
}