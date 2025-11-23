using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.JsonConverters
{
    internal class CheckboxCellConverter : SingleAsArrayConverter<bool>
    {
        public override JsonToken IdentityToken => JsonToken.Boolean;

        public override bool ReadSingle(JsonReader reader, JsonSerializer serializer)
        {
            return reader.ReadAsBoolean().Value;
        }
    }
}
