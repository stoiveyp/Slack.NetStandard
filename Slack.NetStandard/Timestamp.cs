using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard
{
    [JsonConverter(typeof(TimestampConverter))]
    public class Timestamp:IComparable<Timestamp>
    {
        public static implicit operator Timestamp(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            var pieces = value.Split(new []{'.'},2);
            if (pieces.Length != 2)
            {
                return null;
            }
            return new Timestamp(long.Parse(pieces[0]), long.Parse(pieces[1]));
        }

        public Timestamp() { }

        public Timestamp(long epochSeconds, long identifier)
        {
            EpochSeconds = epochSeconds;
            Identifier = identifier;
        }

        public long EpochSeconds { get; set; }

        public long Identifier { get; set; }

        public int CompareTo(Timestamp other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var epochSecondsComparison = EpochSeconds.CompareTo(other.EpochSeconds);
            if (epochSecondsComparison != 0) return epochSecondsComparison;
            return Identifier.CompareTo(other.Identifier);
        }
    }
}
