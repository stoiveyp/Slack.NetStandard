using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.EventsApi;
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
                        if (envelope.Type != null && envelope.Type == "slash_commands")
                        {
                            envelope.Payload = new SlashCommand(serializer.Deserialize<Dictionary<string, string>>(reader));
                        }
                        else
                        {
                            payload = JObject.Load(reader);
                        }

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

            if (envelope.Payload == null)
            {
                return PostObjectPayload(serializer, envelope, payload);
            }

            return envelope;
        }

        private Envelope PostObjectPayload(JsonSerializer serializer, Envelope envelope, JObject payload)
        {
            if (payload == null)
            {
                return envelope;
            }

            switch (envelope.Type)
            {
                case "slash_commands":
                    envelope.Payload =
                        new SlashCommand(payload.Properties().ToDictionary(p => p.Name, p => p.Value.ToString()));
                    break;
                case "interactive":
                    var interaction = serializer.Deserialize<InteractionPayload>(payload.CreateReader());
                    envelope.Payload = interaction;
                    break;
                case "events_api":
                    var evt = serializer.Deserialize<ICallbackEvent>(payload.CreateReader());
                    envelope.Payload = evt;
                    break;
                default:
                    envelope.Payload = payload;
                    break;
            }

            return envelope;
        }
    }
}

