using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.JsonConverters
{
    public class MessageBlockConverter : JsonConverter<IMessageBlock>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, IMessageBlock value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IMessageBlock ReadJson(JsonReader reader, Type objectType, IMessageBlock existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            if (string.IsNullOrWhiteSpace(componentType))
            {
                return null;
            }
            var target = GetComponent(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"MessageBlock type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> IMessageBlockLookup = new()
        {
            {nameof(Divider).ToLower(), typeof(Divider)},
            {nameof(Section).ToLower(), typeof(Section)},
            {nameof(Image).ToLower(),typeof(Image) },
            {nameof(Actions).ToLower(),typeof(Actions) },
            {nameof(Context).ToLower(),typeof(Context) },
            {nameof(Input).ToLower(),typeof(Input) },
            {nameof(File).ToLower(),typeof(File) },
            {nameof(Header).ToLower(),typeof(Header) },
            {RichText.MessageBlockType,typeof(RichText) },
            {nameof(Video).ToLower(), typeof(Video) },
            {nameof(Call).ToLower(), typeof(Call) },
            {nameof(Markdown).ToLower(), typeof(Markdown) }
        };

        private IMessageBlock GetComponent(string type)
        {
            return (IMessageBlock) (
                IMessageBlockLookup.ContainsKey(type)
                    ? Activator.CreateInstance(IMessageBlockLookup[type])
                    : new UnknownBlock());
        }
    }
}
