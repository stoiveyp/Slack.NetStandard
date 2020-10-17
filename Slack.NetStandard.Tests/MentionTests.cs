using System;
using System.Collections.Generic;
using System.Text;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.TextEntities;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class MentionTests
    {
        [Fact]
        public void User()
        {
            Assert.Equal("<@U1234>", UserMention.Text("U1234"));
        }

        [Fact]
        public void ChannelId()
        {
            Assert.Equal("<#C1234>", ChannelMention.Text("C1234"));
        }

        [Fact]
        public void Group()
        {
            Assert.Equal("<!subteam^SAZ94GDB8>", Subteam.Text("SAZ94GDB8"));
        }

        [Fact]
        public void Here()
        {
            Assert.Equal("<!here>", SpecialMention.Here);
        }

        [Fact]
        public void Channel()
        {
            Assert.Equal("<!channel>", SpecialMention.Channel);
        }

        [Fact]
        public void Everyone()
        {
            Assert.Equal("<!everyone>", SpecialMention.Everyone);
        }

        [Fact]
        public void LinkMention()
        {
            Assert.Equal("<!https://test>", Link.Text("https://test"));
        }

        [Fact]
        public void LinkWithLabel()
        {
            Assert.Equal("<!https://test|test>", Link.Text("https://test", "test"));
        }

        [Fact]
        public void Date()
        {
            Assert.Equal("<!date^1392734382^Posted {date_num} {time_secs}|Posted 2014-02-18 6:39:42 AM PST>", DateMention.Text(1392734382, "Posted {date_num} {time_secs}", "Posted 2014-02-18 6:39:42 AM PST"));
        }

        [Fact]
        public void DateWithUrl()
        {
            Assert.Equal("<!date^1392734382^{date_short}^https://example.com/|Feb 18, 2014 PST>", DateMention.Text(1392734382, "{date_short}", "Feb 18, 2014 PST", "https://example.com/"));
        }
    }
}
