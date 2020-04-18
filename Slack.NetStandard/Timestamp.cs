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
            return new Timestamp(long.Parse(pieces[0]), pieces.Length > 1 ? pieces[1] : null);
        }

        public Timestamp() { }

        public Timestamp(long epochSeconds, string identifier = null)
        {
            EpochSeconds = epochSeconds;
            Identifier = identifier;
        }

        public long EpochSeconds { get; set; }

        public string Identifier { get; set; }

        public override string ToString()
        {
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
            return string.Compare(Identifier, other.Identifier, StringComparison.Ordinal);
        }
    }
}
