using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard
{
    [JsonConverter(typeof(TimestampConverter))]
    public class Timestamp : IComparable<Timestamp>
    {
        public static implicit operator Timestamp(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            var pieces = value.Split(new[] { '.' }, 2).Select(long.Parse).ToArray();
            return new Timestamp(pieces[0], pieces.Length > 1 ? (long?)pieces[1] : null);
        }

        public Timestamp() { }

        public Timestamp(long epochSeconds, long? identifier = null)
        {
            EpochSeconds = epochSeconds;
            Identifier = identifier;
        }

        public long EpochSeconds { get; set; }

        public long? Identifier { get; set; }

        public int CompareTo(Timestamp other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var epochSecondsComparison = EpochSeconds.CompareTo(other.EpochSeconds);
            if (epochSecondsComparison != 0) return epochSecondsComparison;
            return Nullable.Compare(Identifier, other.Identifier);
        }

        public override string ToString()
        {
            if (Identifier.HasValue)
            {
                return EpochSeconds + "." + Identifier.Value;
            }

            return EpochSeconds.ToString();
        }
    }
}
