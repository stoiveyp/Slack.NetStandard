using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Interaction;
using Slack.NetStandard.Socket;

namespace Slack.NetStandard.JsonConverters
{
    public class EnvelopeConverter : JsonConverter<Envelope>
    {
        private CallbackEventConverter EventConverter = new();
        private InteractionPayloadConverter PayloadConverter = new();

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Envelope value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Envelope ReadJson(JsonReader reader, Type objectType, Envelope existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var envelope = new Envelope();
            reader.Read();
            if (reader.TokenType != JsonToken.PropertyName)
            {
                return envelope;
            }

            JObject payload = null;
            while (reader.TokenType == JsonToken.PropertyName)
            {
                switch (reader.Value.ToString())
                {
                    case "envelope_id":
                        envelope.EnvelopeId = reader.ReadAsString();
                        reader.Read();
                        break;

                    case "type":
                        envelope.Type = reader.ReadAsString();
                        reader.Read();
                        break;
                    case "payload":
                        reader.Read();
                        payload = JObject.Load(reader);
                        reader.Read();
                        break;
                    case "accepts_response_payload":
                        envelope.AcceptsResponsePayload = reader.ReadAsBoolean() ?? false;
                        reader.Read();
                        break;
                    default:
                        envelope.Otherfields ??= new Dictionary<string, object>();
                        var name = reader.Value.ToString();
                        reader.Read();
                        envelope.Otherfields.Add(name, reader.Value);
                        reader.Read();
                        break;
                }
            }

            if (payload == null)
            {
                return envelope;
            }

            if (envelope.Type == "slash_commands")
            {
                envelope.Payload =
                    new SlashCommand(payload.Properties().ToDictionary(p => p.Name, p => p.Value.ToString()));
                return envelope;
            }

            if (envelope.Type != "interactive")
            {
                envelope.Payload = payload;
                return envelope;
            }

            var interactionType = payload.Value<string>("type");
            var eventType = CallbackEventConverter.GetEventType(interactionType, payload);
            if (eventType.GetType() != typeof(CallbackEvent))
            {
                serializer.Populate(payload.CreateReader(), eventType);
                envelope.Payload = eventType;
                return envelope;
            }

            var interaction = InteractionPayloadConverter.GetPayloadType(interactionType);
            if (interaction != null)
            {
                serializer.Populate(payload.CreateReader(), interaction);
                envelope.Payload = interaction;
            }
            else
            {
                envelope.Payload = payload;
            }

            return envelope;
        }
    }
}

