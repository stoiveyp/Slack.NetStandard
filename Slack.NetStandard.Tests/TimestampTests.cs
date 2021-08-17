using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class TimestampTests
    {
        [Fact]
        public void NumericTimestamp()
        {
            Timestamp ts = "1548261231.000200";
            Assert.Equal("1548261231.000200",ts.ToString());
            Assert.Equal(1548261231, ts.EpochSeconds);
            Assert.Equal("000200", ts.Identifier);
        }

        [Fact]
        public void StringTimestamp()
        {
            var unfurlMsId = "Uxxxxxxx-909b5454-75f8-4ac4-b325-1b40e230bbd8-gryl3kb80b3wm49ihzoo35fyqoq08n2y";
            Timestamp ts = unfurlMsId;
            Assert.Equal(unfurlMsId, ts.ToString());
            Assert.Equal(0,ts.EpochSeconds);
            Assert.Null(ts.Identifier);
            Assert.Equal(unfurlMsId, ts.RawValue);
        }
    }
}
