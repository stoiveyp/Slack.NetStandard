using System;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard
{
    [JsonConverter(typeof(TimestampConverter))]
    public class Timestamp : IComparable<Timestamp>
    {
        public static implicit operator Timestamp(long value)
        {
            return new Timestamp(value);
        }

        public static implicit operator Timestamp(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            var pieces = value.Split(new[] { '.' }, 2);

            if (!long.TryParse(pieces[0], out var epochSeconds))
            {
                return new Timestamp(value, epochSeconds);
            }

            return new Timestamp(value, epochSeconds, pieces.Length > 1 ? pieces[1] : null);
        }

        public static implicit operator string(Timestamp value)
        {
            return value.ToString();
        }

        public Timestamp() { }

        public Timestamp(long epochSeconds, string identifier = null)
        {
            EpochSeconds = epochSeconds;
            Identifier = identifier;
        }

        public Timestamp(string raw, long epochSeconds, string identifier = null) : this(epochSeconds, identifier)
        {
            RawValue = raw;
        }

        public long EpochSeconds { get; set; }

        public string Identifier { get; set; }

        public string RawValue { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(RawValue))
            {
                return RawValue;
            }

            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                return EpochSeconds + "." + Identifier;
            }

            return EpochSeconds.ToString();
        }

        public int CompareTo(Timestamp other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var epochSecondsComparison = EpochSeconds.CompareTo(other.EpochSeconds);
            if (epochSecondsComparison != 0) return epochSecondsComparison;
            var identifierComparison = string.Compare(Identifier, other.Identifier, StringComparison.Ordinal);
            if (identifierComparison != 0) return identifierComparison;
            return string.Compare(RawValue, other.RawValue, StringComparison.Ordinal);
        }
    }
}
